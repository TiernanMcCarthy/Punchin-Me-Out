using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTimer : MonoBehaviour {

    public Text timerText;
    public float startTime;
    public float t;
    public float m;
    private float delayedTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;

	}

    public void Reset()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update () {
        t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        timerText.text = minutes + ":" + seconds;

        if (t == 10.00f)
        {
            delayedTime = Time.time;
        }

        if ( t >= 10.00f)
        {
            m = Time.time - delayedTime;
        }
	}
}
