using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outercirclestuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="player1")
        {

        }
    }
}
