using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OperacionPorPantalla : MonoBehaviour {
    GameObject letra;


    public GameObject n0;
    public GameObject n1;
    public GameObject n2;
    public GameObject n3;
    public GameObject n4;
    public GameObject n5;
    public GameObject n6;
    public GameObject n7;
    public GameObject n8;
    public GameObject n9;
    public GameObject sum;
    public GameObject rest;
    public GameObject mult;
    public GameObject div;
    public GameObject igual;

    int numLetras = 0;
    List<GameObject> letrasList = new List<GameObject>();
    GameObject[] letras;
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

	}
   public GameObject getNumber(char c)
    {
        switch (c)
        {
            case '0':
                return n0;
                break;
            case '1':
                return n1;
                break;
            case '2':
                return n2;
                break;
            case '3':
                return n3;
                break;
            case '4':
                return n4;
                break;
            case '5':
                return n5;
                break;
            case '6':
                return n6;
                break;
            case '7':
                return n7;
                break;
            case '8':
                return n8;
                break;
            case '9':
                return n9;
                break;
            case '+':
                return sum;
                break;
            case '-':
                return rest;
                break;
            case 'x':
            case 'X':
                return mult;
                break;
            case '/':
                return div;
                break;
            case '=':
                return igual;
                break;
            default:
                return null;
                break;
        }
    }

    public void drawOp(string st)
    {
        Debug.Log(st);
        char[] ch = st.ToCharArray();
        for(int i=0;i<ch.Length;i++)
        {
            if (ch[i] != ' ')
            {
                letra = getNumber(ch[i]);
                Vector3 temp = new Vector3(transform.position.x + (i * 2), transform.position.y, transform.position.z);
                letrasList.Add(Instantiate(letra, temp, Quaternion.Euler(0, 180, 0)) as GameObject);
                numLetras++;
            }
        }
        letras = letrasList.ToArray();
        letrasList.Clear();
    }

    public void borrarLetras()
    {
        for(int i= numLetras-1; i>=0; i--)
        {
            Destroy(letras[i]);
        }

        numLetras = 0;
    }
}
