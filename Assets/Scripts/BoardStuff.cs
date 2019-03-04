using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStuff : MonoBehaviour {
    public GameObject piece;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="circle")
        {
            Destroy(piece);
            Debug.Log("HELLO");
            Destroy(this.gameObject);
        }
    }
     void OnCollisionEnter(Collision collision)
    {
        Debug.Log("PLEASE");
    }
}
