using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    const int ARRAYLENGTH = 7;

    public float GAMESPEED = 1;

    public int operationsLeft;
    
    int score = 0;
    public float deltaTime;
    public GameObject door;
    public float[] startX = new float[3];
    float y, z;
    Vector3[] doorPos= new Vector3[3];
    int[] operations=new int[7];

    public OperacionPorPantalla oper;
    GameObject[] doors= new GameObject[3];


    IEnumerator<int[]> prng;

    void Start()
    {
        //number generation
        prng = Generator.SRMD(100);


        //positions for door generation
        startX[0] = -4.2f; startX[1] = -0.1f; startX[2] = 3.98f;
        y = 18f;
        z = 12;
        for (int i = 0; i < 3; i++)
            doorPos[i] = new Vector3(startX[i], y, z);

        //generates doors
        StartCoroutine("GenerateDoors");
    }

    public void addScore(bool result)
    {
        score += (result) ? 10 : -10;
        Debug.Log(score);
    }

    void generateOperation()
    {
        //FUNCIONES DE GUILLERMO
        if (prng.MoveNext())  operations = prng.Current;
    }

    public void receiveOperations(ref int[] operation)
    {
        for (int i=0; i< ARRAYLENGTH; i++) operation[i] = operations[i];
    }



    IEnumerator GenerateDoors()
    {
        GameObject tempDoor;
        generateOperation(); // takes operation
        oper.drawOp(Generator.text(operations)); // draws on screen the operation
        for (int i=0; i<3; i++)
        {
            tempDoor = Instantiate(door, doorPos[i], Quaternion.Euler(90, 180, 0)) as GameObject;
            tempDoor.GetComponent<Door>().doorIndex = i;
            doors[i] = tempDoor;
            tempDoor.transform.parent = transform;
        }
        yield return new WaitForSeconds(deltaTime);
        StartCoroutine("GenerateDoors");
    }

    public void RevealColor()
    {
        foreach (GameObject door in doors)
        {
            if (door.GetComponent<Door>().answer) door.GetComponent<Door>().lightMat.SetColor("_Color", Color.green);
            else door.GetComponent<Door>().lightMat.SetColor("_Color", Color.red);
        }
    }

    public void operationsLeftminus1()
    {
        operationsLeft--;
        if (operationsLeft <= 0) Time.timeScale = 0; //stop the game
    }

    public void deleteOperation()
    {
        oper.borrarLetras();
    }
}
