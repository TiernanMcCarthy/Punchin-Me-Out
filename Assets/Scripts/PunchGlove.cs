using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchGlove : MonoBehaviour {
    public float damage;
    public float force;
    private float original;
    private float animTime;
    Animator m_Animator;
    public string WhoAmI;
    private BaseTimer timerScript;
    float m_MySliderValue;
    // Use this for initialization
    void Start () {
        m_Animator = gameObject.GetComponent<Animator>();
        timerScript = FindObjectOfType<BaseTimer>();
        original = force;
    }
   public void playanimation()
    {
        if (m_Animator.GetBool("Play") != true)
        {
            animTime = timerScript.t;
            force = force * 1.3f;
            //m_Animator.ResetTrigger(0);
            m_Animator.SetBool("Play", true);
        }

    }
	// Update is called once per frame
	void Update () {
		if(timerScript.t-animTime>0.8f)
        {
            m_Animator.SetBool("Play", false);
            force = original;
            //force = 1.0f;
        }
        else if(timerScript.t-animTime<0.4f)
        {
            //force = 10.0f;
        }
	}
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="player1" && WhoAmI!="player1")
        {
            collision.gameObject.GetComponent<PlayerFinal>().hitbysomething(transform.rotation.eulerAngles.z, force);
        }
        if (collision.gameObject.tag == "player2" && WhoAmI != "player2")
        {
            collision.gameObject.GetComponent<PlayerFinal>().hitbysomething(transform.rotation.eulerAngles.z, force);
        }
    }
}
