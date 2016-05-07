using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    const int OPERATOR = 1;
    const int SOLUTION = 6;

    public bool answer; //si es la puerta buena
    public int doorIndex; //que puerta es. 0,1,2
    //char op; //que operación es
    int[] operation= new int[7]; //donde guardo datos de operacion
    GameController controller;
    public Renderer rend;
    public Material lightMat;
    Movement movement;

    Global glob;
    // Use this for initialization
    void Start () {
        doorIndex += 2;
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        controller.receiveOperations(ref operation);
        processData();

        rend = GetComponent<Renderer>();
        lightMat = rend.materials[4];

        glob = GameObject.Find("GameController").GetComponent<Global>();
        movement = GameObject.Find("CalculatorPlayer").GetComponent<Movement>();


        lightMat.SetColor("_Color", Color.black);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(0, 0, -0.5f*controller.GAMESPEED);
	}

    void OnTriggerEnter(Collider col)
    {
        //SET COLOR OF THE LIGHT
        controller.RevealColor();

        if (col.gameObject.name == "Destructor")
        {
            Destroy(gameObject);
            controller.deleteOperation(); //deletes operation from HUD
        }
        if (col.gameObject.name == "CalculatorPlayer") {

            //REDUCES NUMBER OF OPERATIONS LEFT AND CHECKS IF THE LEVEL IS COMPLETED
            controller.operationsLeftminus1();

            //BLOCK PLAYER MOVEMENT
            movement.canMove = false;

            //ADD SCORE
            controller.addScore(answer);

            //SLOWMO
            //Time.timeScale = 0.2f; 
            if (!answer) controller.GAMESPEED = 0.3f;

            //STARTS ANIMATION + PARTICLE SYSTEMs
            if (!answer) StartCoroutine("setAnimWrong");
            else StartCoroutine("setAnimCorrect");
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "CalculatorPlayer")
        {
            //ENABLES PLAYER MOVEMENT
            movement.canMove = true;

            //REMOVES SLOWMO
            //Time.timeScale = 1;
            controller.GAMESPEED = 1;
        }
    }

    IEnumerator setAnimWrong() {
        glob.setAnimWrong();
        yield return new WaitForEndOfFrame();
        glob.setAnimRun();

        yield return new WaitForSeconds(0.3f);
        movement.loose.Play(true);

    }
    IEnumerator setAnimCorrect() {
        glob.setAnimCorrect();
        yield return new WaitForEndOfFrame();
        glob.setAnimRun();

        yield return new WaitForSeconds(0.3f);
        movement.win.Play();
    }


    void processData()
    {
        answer = (operation[doorIndex] == operation[SOLUTION]);
        /*switch (operation[OPERATOR])
        {
            case 0: op = '+';
                break;
            case 1: op = '-';
                break;
            case 2: op = 'x';
                break;
            case 3: op = '/';
                break;
            default: Debug.Log("ERROR: OPERATION UNDEFINDED");
                break;
        }*/
    }
}
