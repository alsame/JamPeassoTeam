using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Movement : MonoBehaviour {
    public Vector2 startPos;
    public Vector2 direction;

    bool touching=false;
    bool canTouch = true;
    int PositionAct=1;
    public float[] positions; 
    public float changeVelocity = 0.3f;

    public ParticleSystem win, loose;

    Global glob;
    public bool canMove;

    // Use this for initialization
    void Start () {
        positions=GameObject.Find("GameController").GetComponent<GameController>().startX;
        glob = GameObject.Find("GameController").GetComponent<Global>();
        glob.setAnimRun(); //corre
        canMove = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (canMove)
        {
             if (Input.touchCount > 0)
             {
                 var touch = Input.GetTouch(0);


                 switch (touch.phase)
                 {
                     // Record initial touch position.
                     case TouchPhase.Began:
                         canTouch = true;
                         startPos = touch.position;
                         break;

                     // Determine direction by comparing the current touch position with the initial one.
                     case TouchPhase.Moved:
                         direction = touch.position - startPos;
                         int pixeltot = Screen.width;
                         float vect = pixeltot * 15 / 100;
                         if (Mathf.Abs(direction.x) > vect && canTouch)
                         {
                             if (direction.x > 0)
                             {
                                 canTouch = false;
                                 Mov(1);
                             }
                             else
                             {
                                 canTouch = false;
                                 Mov(2);
                             }
                         }

                         break;

                     // Report that a direction has been chosen when the finger is lifted.
                     case TouchPhase.Ended:
                         canTouch = true;
                         break;
                 }
             }/*


            if (Input.GetKeyDown(KeyCode.A))   //For debug
            {
                Mov(2);


            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Mov(1);
            }*/
        }
        //Actualizar posicion

        Vector3 temp = new Vector3(positions[PositionAct], transform.position.y, transform.position.z);//target Movetowards
        transform.position = Vector3.MoveTowards(transform.position, temp, changeVelocity);
    }



    void Mov(int dir)
    {
        switch (dir)
        {
            case 1:
                if (PositionAct < 2)
                {
                    PositionAct++;
                }
                break;
            case 2:
                if (PositionAct > 0)
                {
                    PositionAct--;
                }
                break;
        }
    }
}
