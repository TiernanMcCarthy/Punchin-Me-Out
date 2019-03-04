using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {
    public int CollectableType;
    public GameObject stage; //Used to spawn objects within the stage 
    public float health;
    public float ammo;
    public float speed;
    public float damage;
    public bool shoot;
    public float stageRadius;
    private bool collected = false;
    public PlayerFinal player1;
    public PlayerFinal player2;
    private float MattsClockyBoii;
    public GameObject goodPickup; // Added to test some shit. - Matt
    public GameObject badPickup;
    // Use this for initialization
    void reset()
    {
        health = 0;
        ammo = 0;
        speed = 0;
        damage = 0;
        shoot = true; 
    }
    void set()
    {
        switch (CollectableType)
        {
            case 1:   //Healthpack
                reset();
                health = 10.0f;
                break;
            case 2: //Ammo
                reset();
                ammo = 10.0f;
                break;
            case 3:
                reset();
                speed = 1.5f;
                break;
            case 4:
                reset();
                damage = 1.5f;
                break;
            case 5:
                reset();
                shoot = false;
                break;
            case 6:
                reset();
                health = -1;
                break;
            case 7:
                reset();
                ammo = 0;
                break;
            case 8:
                reset();
                speed = -1.5f;
                break;
            case 9:
                reset();
                damage = -1.5f;
                break;
        }
    }
	void Start () {
        randomboiis();
        player1.GetComponent<PlayerFinal>();
        spawn();
	}
    void spawn()
    {
        transform.position = stage.transform.position;
       // while (distance < stageRadius)
        //{
           // pythag(stage.transform.position.x, transform.position.x, stage.transform.position.y, transform.position.y);
        //}

    }
    float pythag(float x1,float x2, float y1, float y2)
    {
        float temp1 = (x1 - x2) * (x1 - x2);
        float temp2= (y1 - y2) * (y1 - y2);
        float result = (float) System.Math.Sqrt(temp1 + temp2);
        return result;
    }

	void randomboiis()
    {
        System.Random rnd = new System.Random();
        CollectableType=rnd.Next(1, 10);
        set();
    }
     void OnTriggerEnter2D(Collider2D collision)
     {
        
         if (collision.gameObject.tag=="player1")
         {

            switch (CollectableType)
            {
                case 1:   //Healthpack
                    player1.setHealth(health);
                    break;
                case 2: //Ammo
                    player1.setbullets(ammo);
                    break;
                case 3:
                    player1.setSpeed(speed);
                    break;
                case 4:
                    player1.setDamage(damage);
                    break;
                case 5:
                    player1.canIshoot(shoot);
                    break;
                case 6:
                    player1.setHealth(health);
                    break;
                case 7:
                    player1.setbullets(ammo);
                    break;
                case 8:
                    player1.setSpeed(speed);
                    break;
                case 9:
                    player1.setDamage(damage);
                    break;
            }
            transform.position = new Vector2(200, 200);
         }
       if(collision.gameObject.tag=="player2")
        {
            switch (CollectableType)
            {
                case 1:   //Healthpack
                    player2.setHealth(health);
                    break;
                case 2: //Ammo
                    player2.setbullets(ammo);
                    break;
                case 3:
                    player2.setSpeed(speed);
                    break;
                case 4:
                    player2.setDamage(damage);
                    break;
                case 5:
                    player2.canIshoot(shoot);
                    break;
                case 6:
                    player2.setHealth(health);
                    break;
                case 7:
                    player2.setbullets(ammo);
                    break;
                case 8:
                    player2.setSpeed(speed);
                    break;
                case 9:
                    player2.setDamage(damage);
                    break;
            }
            transform.position = new Vector2(200, 200);
        }
     }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oiii");
        if (collision.gameObject.tag == "Player")
        {

        }
    }
    // Update is called once per frame
    void Update () {
        if (collected == true && MattsClockyBoii==-3.0f)   //Run his clock as a countdown for when the next powerup is there
        {
            //MattsClockyBoii = hisactualclockfunctionplease; Temp
            //spawn();
        }
        else if(MattsClockyBoii==15.0f)  //15 seconds for the powerup
        {
            spawn();
        }
	}
}
