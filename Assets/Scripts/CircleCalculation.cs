using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CircleCalculation : MonoBehaviour {

    public float circleRadius;
    public float currentCircleSize;
    public GameObject PLAYER;
    public GameObject PLAYER2;
    public float xPlayerPosition;
    public float yPlayerPosition;
    public float xCircleCenter;
    public float yCircleCenter;
    public float gameLength;
    // Tiernan keep seperate the public and private vars please.
   // public Circle local;  //Create a variable to access this object
    public BaseTimer timerScript;
    private BaseTimer matthewTimer;
    private bool inCircle;
    private float xPlayerSquared;
    private float yPlayerSquared;
    private float distanceFromCenter;
    private float circlePercentage = 100;
    // timerScript.t This is how you call the BaseTimer

    // Use this for initialization
    void Start () {
        //local = FindObjectOfType<Circle>(); //Actually fill the variable with something
        timerScript = FindObjectOfType<BaseTimer>();
        matthewTimer = FindObjectOfType<BaseTimer>();
        xCircleCenter = transform.position.x;
        yCircleCenter = transform.position.y;
    }
    public void restartTime()
    {
      // timerScript.startTime = Time.time;
        //currentCircleSize = circleRadius;
    }
    // Update is called once per frame
    void Update()
    {
        xPlayerPosition = PLAYER.transform.position.x;
        yPlayerPosition = PLAYER.transform.position.y;
        xPlayerSquared = (xCircleCenter - xPlayerPosition) * (xCircleCenter - xPlayerPosition);
        yPlayerSquared = (yCircleCenter - yPlayerPosition) * (yCircleCenter - yPlayerPosition);

        distanceFromCenter = Mathf.Sqrt(xPlayerSquared + yPlayerSquared);

        if (distanceFromCenter < circleRadius)
        {
            inCircle = false;
        }

        /*if (timerScript.t >= 10.00f && timerScript.t <20.00f)//Circle Size Redundant.
        {
            currentCircleSize = circleRadius * 0.9f;
        }
        else if (timerScript.t >= 20.00f && timerScript.t < 30.00f)
        {
            currentCircleSize = circleRadius * 0.75f;
        }
        else if (timerScript.t >= 30.00f && timerScript.t < 40.00f)
            {
            currentCircleSize = circleRadius * 0.5f;
        }
        else if (timerScript.t >= 40.00f)
            {
            currentCircleSize = circleRadius * 0.25f;
        }*/

        if (timerScript.t >= 10.00f)
        {
            //circlePercentage = circlePercentage - timerScript.t;This code might be dead. Delete Wednesday if you can't find use.
            circlePercentage = (timerScript.m -10.00f) / gameLength;
            currentCircleSize = circleRadius * (1 - circlePercentage);
            transform.localScale = new Vector3(currentCircleSize, currentCircleSize, 1);
        }
        else if(timerScript.t<10.0f)
        {
            currentCircleSize = circleRadius;
            transform.localScale = new Vector3(currentCircleSize, currentCircleSize, 1);
        }


        //  currentCircleSize = circlePercentage / circleRadius * 100; This code might be dead. Delete Wednesday if you can't find use.
    }


}