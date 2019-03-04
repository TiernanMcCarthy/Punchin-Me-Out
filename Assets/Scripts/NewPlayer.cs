using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour {

    public float speed;
    public float health;
    public float rotateamount;
    private float rotation;
    private char dir = 'n';
    private bool thrusting = false;
    private bool Break;
    private string[] ControlList = new string[4];  //Left, Right, Forwards, Break
    private float directionX, directionY = 0; //Holds the temporary direction of new velocity
    public float velocityX, velocityY = 0; //Holds the actual direction but is affected by the direction variables

    // Use this for initialization
    void Start()
    {
        ControlList[0] = "a";
        ControlList[1] = "d";
        ControlList[2] = "w";
        ControlList[3] = "s";
    }
    void InputCode()
    {
        if (Input.GetKeyDown(ControlList[0]))  //Rotate Left
        {
            dir = 'l';
        }
        if (Input.GetKeyDown(ControlList[1])) //Rotate Right
        {
            dir = 'r';
        }
        if (Input.GetKeyDown(ControlList[2])) //Go forwards duuuhhhhhh
        {
            dir='u';
        }
        if (Input.GetKeyDown("s")) //Go forwards duuuhhhhhh
        {
            dir = 'd';
        }
         if (Input.GetKeyDown(ControlList[3])) //BReak
        {
            Break = true;
        }
        if (Input.GetKeyUp(ControlList[0]))
        {
            dir = 'n';
        }
        if (Input.GetKeyUp(ControlList[1]))
        {
            dir = 'n';
        }
        if (Input.GetKeyUp(ControlList[2]))
        {
            dir = 'n';
            //directionX = 0; directionY = 0;
        }
        if (Input.GetKeyUp("s"))
        {
            dir = 'n';
            //directionX = 0; directionY = 0;
        }
    }

    void Movement()
    {
        if (dir == 'l') //If wanting to move left, rotate left e.t.c
        {
            transform.Translate(-speed*Time.deltaTime, 0, 0, Space.World);
        }
        else if (dir == 'r')
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        }
        else if(dir=='u')
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        }
        else if (dir == 'd')
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
        }
        if (thrusting==true)
        {
            directionX = speed * Mathf.Cos(transform.rotation.eulerAngles.z);

            transform.position = new Vector2(transform.position.x + directionX,0);
        }
    }
    // Update is called once per frame
    void Update () {
        InputCode();
        Movement();
	}
}
