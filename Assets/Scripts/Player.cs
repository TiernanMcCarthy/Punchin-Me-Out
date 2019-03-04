using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public float health;
    public float rotateamount;
    private char dir = 'n';
    private bool thrusting = false;
    private bool Break;
    private string[] ControlList = new string[4];  //Left, Right, Forwards, Break
    private float directionX, directionY = 0; //Holds the temporary direction of new velocity
    public float velocityX, velocityY = 0; //Holds the actual direction but is affected by the direction variables

	// Use this for initialization
	void Start () {
        ControlList[0] = "a";
        ControlList[1] = "d";
        ControlList[2] = "w";
        ControlList[3] = "s";
	}
	void InputCode()
    {
        if(Input.GetKeyDown(ControlList[0]))  //Rotate Left
        {
            dir = 'l';
        }
        else if(Input.GetKeyDown(ControlList[1])) //Rotate Right
        {
            dir = 'r';
        }
        if(Input.GetKeyDown(ControlList[2])) //Go forwards duuuhhhhhh
        {
            thrusting = true;
        }

        else if(Input.GetKeyDown(ControlList[3])) //BReak
        {
            Break = true;
        }
        if(Input.GetKeyUp(ControlList[0]))
        {
            dir = 'n';
        }
        if (Input.GetKeyUp(ControlList[1]))
        {
            dir = 'n';
        }
        if (Input.GetKeyUp(ControlList[2]))
        {
            thrusting = false;
            directionX = 0; directionY = 0;
        }
        //  if(Input.GetKeyUp(ControlList[0])&& dir!='r' || Input.GetKeyUp(ControlList[1]) && dir != 'l')  //If left key up equals true and the other key isn't being pressed
        //   {
        //     dir = 'n';
        // }

    }
    void Movement()
    {
        if (dir == 'l') //If wanting to move left, rotate left e.t.c
        {
            //transform.rotation = new Quaternion(0,0,transform.rotation.eulerAngles.z- rotateamount * Time.deltaTime,0);
            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.z += rotateamount ;
            transform.rotation = Quaternion.Euler(newRotation);
            // transform.rotation = new Quaternion(0, 0, transform.rotation.eulerAngles.z + 10,0);
        }
        else if (dir == 'r')
        {
            // transform.Rotate(0, 0, -rotateamount);
            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.z -= rotateamount ;
            transform.rotation = Quaternion.Euler(newRotation);
        }
        if (thrusting==true)
        {
            // directionX = (speed * Mathf.Cos(transform.rotation.z));
            // directionY = (speed * Mathf.Sin(transform.rotation.z));
            directionX = speed * Mathf.Cos(transform.rotation.z);
            directionY = speed * Mathf.Sin(transform.rotation.z);
        // velocityX += directionX;
           // velocityY += directionY;
        }
        transform.Translate(directionX, directionY,0);
       //transform.position = new Vector2(transform.position.x + directionX, transform.position.y + directionY);
    }

	// Update is called once per frame
	void Update () {
        InputCode();
        Movement();
	}
}
// (CircleCentre.x-Player.x) (CircleCentre.y-Player.y) 
// (transform.postion.x) 