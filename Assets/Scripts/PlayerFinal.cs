using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinal : MonoBehaviour {
    public float speed;
    public float health=0;
    public PunchGlove Punchy;
    public float rotateamount;
    public PlayerFinal player2;
    private HitterDecider Hitty;
    public string whatAmI;
    public Transform spawn;
    public GameObject example;
    public float force;
    public float ammo =10;
    public Rigidbody2D littlebullet;
    private float damage=1;
    private bool canshoot;
    private char dir = 'n';
    private Collider2D COllidery;
    public Transform GunLeft;
    private bool alive;
    public Transform GunRight;
    private Rigidbody2D rig2d;
    private BaseTimer timerScript;
    private float DamageUpperLimit=40;
    private bool firing;
    private float temptime=-10;
    private bool thrusting = false;
    private bool Break;
    private string[] ControlList = new string[6];  //Left, Right, Forwards, Break, Shoot
    private float directionX, directionY = 0; //Holds the temporary direction of new velocity
    public float velocityX, velocityY = 0; //Holds the actual direction but is affected by the direction variables
                                           // Use this for initialization

    public float explosionRadius = 5.0F;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void Start() {
        if (whatAmI == "player1")
        {
            ControlList[0] = "a"; //Left, Right, Forwards, Break, Shoot, Punch
            ControlList[1] = "d";
            ControlList[2] = "w";
            ControlList[3] = "s";
            ControlList[4] = "f";
            ControlList[5] = "e";

        }
        else
        {
            ControlList[0] = "left"; //Left, Right, Forwards, Break, Shoot, Punch
            ControlList[1] = "right";
            ControlList[2] = "up";
            ControlList[3] = "down";
            ControlList[4] = "/";
            ControlList[5] = ";";
        }
        timerScript = FindObjectOfType<BaseTimer>();
        rig2d = GetComponent<Rigidbody2D>();
        Hitty = FindObjectOfType<HitterDecider>();
        COllidery = GetComponent<Collider2D>();
        alive = true;
        transform.position = spawn.transform.position;
    }
    public void hitbysomething(float angle, float force)
    {
        //Make it affected by the player's health multiplier
        velocityX += (force * Mathf.Cos(angle* 0.01745f)) * Time.deltaTime;
        velocityY += (force * Mathf.Sin(angle* 0.01745f)) * Time.deltaTime;
    }
    float AngleOfVector(float x,float y)
    {
        float angle = Mathf.Atan2(y, x);
        return angle;
    }
    void spawn3()
    {
        transform.position = spawn.transform.position;
        if(whatAmI=="player1")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        COllidery.enabled = true;
        velocityX = 0;
        velocityY = 0;
        speed = 5;
        health = 1;
        rotateamount = 2;
        force = 50;
        ammo = 10;
    }
    void CreateBullet()
    {

        //GameObject NewBullet=GetComponent<Bullet>();
        // NewBullet.spawn(GunLeft.transform.position.x, GunLeft.transform.position.y, transform.rotation.eulerAngles.z, 12);
        //Rigidbody2D NewBullet = ( Instantiate(littlebullet, new Vector3(0, 0, 0), Quaternion.identity));
        if (ammo > 1)
        {
            Rigidbody2D cloneboy;
            GameObject temp;
            temp = (GameObject)Instantiate(example, GunLeft.transform.position, Quaternion.identity);
            cloneboy = temp.GetComponent<Rigidbody2D>();
            cloneboy.gameObject.GetComponent<Bullet>().spawn(GunLeft.transform.position.x, GunLeft.transform.position.y, transform.rotation.eulerAngles.z, 12, whatAmI);

            temp = (GameObject)Instantiate(example, GunRight.transform.position, Quaternion.identity);
            cloneboy = temp.GetComponent<Rigidbody2D>();
            cloneboy.gameObject.GetComponent<Bullet>().spawn(GunRight.transform.position.x, GunRight.transform.position.y, transform.rotation.eulerAngles.z, 12, whatAmI);
            ammo = ammo - 2;
        }
        else if (ammo==1)
        {
            Rigidbody2D cloneboy;
            GameObject temp;
            temp = (GameObject)Instantiate(example, GunLeft.transform.position, Quaternion.identity);
            cloneboy = temp.GetComponent<Rigidbody2D>();
            cloneboy.gameObject.GetComponent<Bullet>().spawn(GunLeft.transform.position.x, GunLeft.transform.position.y, transform.rotation.eulerAngles.z, 12, whatAmI);
            ammo = 0;
        }
        else
        {
            Debug.Log("Out of ammo sonny");
        }
        // GameObject bob = NewBullet.gameObject;
        // NewBullet.gameObject.GetComponent<Bullet>().speed = 3.0f;
        // NewBullet.GetComponent<Bullet>().spawn(GunLeft.transform.position.x, GunLeft.transform.position.y, transform.rotation.eulerAngles.z, 12);
        //NewBullet.gameObject.GetComponentsInChildren<Bullet>();
    }
    void input()
    {
        if(Input.GetKeyDown(ControlList[0]))
        {
            dir = 'l'; //Rotate left
        }
        else if(Input.GetKeyDown(ControlList[1]))  //ROtate right
        {
            dir = 'r';
        }
        if (Input.GetKeyDown(ControlList[2])) //Go forwards
        {
            thrusting = true;
        }
        else if(Input.GetKeyDown(ControlList[3])) //Break
        {
            Break = true;
        }
        if(Input.GetKeyDown(ControlList[4])) //shoot
        {
            CreateBullet();
        }
        if (Input.GetKeyDown(ControlList[5])) //Punch
        {
            Punchy.playanimation();
        }
        if (Input.GetKeyUp(ControlList[0])&& dir!='r') //stop those
        {
            dir = 'n';
        }
        else if(Input.GetKeyUp(ControlList[1]) && dir != 'l')
        {
            dir = 'n';
        }
        if(Input.GetKeyUp(ControlList[2]))
        {
            
            thrusting = false;
        }
        if(Input.GetKeyUp(ControlList[3]))
        {
            Break = false;
        }

    }
    void movement()
    {
        if(dir=='l')
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.eulerAngles.z + rotateamount);
        }
        if (dir == 'r')
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.eulerAngles.z - rotateamount);
        }
        if (thrusting == true)
        {
            velocityX += (speed * Mathf.Cos(transform.rotation.eulerAngles.z * 0.01745f)) * Time.deltaTime;
            velocityY += (speed * Mathf.Sin(transform.rotation.eulerAngles.z * 0.01745f)) * Time.deltaTime;
        }
        else if(Break==true)
        {
            velocityX -= (speed * Mathf.Cos(transform.rotation.eulerAngles.z * 0.01745f))*0.5f * Time.deltaTime;
            velocityY -= (speed * Mathf.Sin(transform.rotation.eulerAngles.z * 0.01745f))*0.5f * Time.deltaTime;
        }
        float tempX = velocityX;
        float tempY = velocityY;
        transform.position = new Vector2(transform.position.x + velocityX * Time.deltaTime, transform.position.y + velocityY * Time.deltaTime);
        /*if(velocityX<0 && velocityY<0)
        {
            force = (velocityX * -1 + velocityY * -1) / DamageUpperLimit;
        }
        else if(velocityX<0 && velocityY>0)
        {
            force = (velocityX * -1 + velocityY) / DamageUpperLimit;
        }
        else if(velocityY<0 && velocityX>0)
        {
            force = (velocityX + velocityY*-1) / DamageUpperLimit;
        }
        else
        {
            force = ((velocityX + velocityY) / DamageUpperLimit)*100;
        }*/
        if(velocityX<0)
        {
            tempX =tempX* -1;
        }
        if (velocityY > 0)
        {
            tempY =tempY -1;
        }
        force = ((tempX + tempY) / DamageUpperLimit*100)+20;
    }
    public void setHealth(float amount)
    {
        if (amount > 0 && health + amount < 100)
        {
            health += amount;
        }
        else if (health + amount > 100)
        {
            health = 100;
        }
        else if (health + amount <= 0)
        {
            health -= amount;
        }
    }
    public void setbullets(float bulletsss)
    {
        ammo = bulletsss;
    }
    public void setDamage(float damaaa)
    {
        damage = damaaa;
    }
    public void canIshoot(bool shoot)
    {
        canshoot = shoot;
    }
    public void setSpeed(float spud)
    {
        speed = spud;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            
        }
        if (collision.gameObject.tag == "bullet")
        {
            Bullet temp = collision.gameObject.GetComponent<Bullet>();
            if(temp.GetComponent<Bullet>().WhoShotme ==whatAmI)
            {
                Debug.Log("you shouldn't even collide");
            }
            else
            {
                //THrow me about but also destroy the bullet
                Debug.Log("die");
                hitbysomething(temp.GetComponent<Bullet>().transform.rotation.eulerAngles.z, temp.GetComponent<Bullet>().force);
                //Bullet.Destroy(temp);
            }
        }
        if(collision.gameObject.tag=="glove")
        {
            //Debug.Log("die");
            PunchGlove Glovey = collision.gameObject.GetComponent<PunchGlove>();
            if(Glovey.GetComponent<PunchGlove>().WhoAmI==whatAmI)
            {
                Debug.Log("Impossible");
            }
            else
            {
                Debug.Log("die");
                //hitbysomething(Glovey.GetComponent<PunchGlove>().transform.rotation.eulerAngles.z, Glovey.GetComponent<PunchGlove>().force);
            }


        }
        if(collision.gameObject.tag=="player1")
        {
            PlayerFinal tempy = collision.gameObject.GetComponent<PlayerFinal>();
            RaycastHit2D ray = Physics2D.Raycast(transform.position,new Vector2(tempy.gameObject.GetComponent<PlayerFinal>().velocityX, tempy.gameObject.GetComponent<PlayerFinal>().velocityX), 7.0f);
            Debug.Log(ray.transform.gameObject.tag);
            if (ray == true && ray.transform.gameObject == tempy.gameObject)
            {
                Hitty.WhoHitWho = "player2";
                velocityX = 0;
                velocityY = 0;
            }
            else if (Hitty.WhoHitWho == "player1")
            {
                //Debug.Log("oiiiiiinki");
                health += damage * collision.gameObject.GetComponent<PlayerFinal>().force;
            }
            //health += damage * collision.gameObject.GetComponent<PlayerFinal>().force;
            hitbysomething(AngleOfVector(tempy.gameObject.GetComponent<PlayerFinal>().velocityX*-1, tempy.gameObject.GetComponent<PlayerFinal>().velocityY*-1), tempy.gameObject.GetComponent<PlayerFinal>().force);
            tempy.gameObject.GetComponent<PlayerFinal>().hitbysomething(AngleOfVector(tempy.gameObject.GetComponent<PlayerFinal>().velocityX , tempy.gameObject.GetComponent<PlayerFinal>().velocityY), tempy.gameObject.GetComponent<PlayerFinal>().force*2);
            //Debug.Log("HAVE YOU ACTUALLY HIT");
        }
        if (collision.gameObject.tag == "player2")
        {
            PlayerFinal tempy = collision.gameObject.GetComponent<PlayerFinal>();
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2(tempy.gameObject.GetComponent<PlayerFinal>().velocityX, tempy.gameObject.GetComponent<PlayerFinal>().velocityX), 7.0f);
            if (ray == true && ray.transform.gameObject == tempy.gameObject)
            {
                Hitty.WhoHitWho = "player1";
                Debug.Log("HELLO");
                velocityX = 0;
                velocityY = 0;
            }
            else if (Hitty.WhoHitWho == "player2")
            {
                //Debug.Log("oiiiiiinki");
                health += damage * collision.gameObject.GetComponent<PlayerFinal>().force;
            }
            //health += damage * collision.gameObject.GetComponent<PlayerFinal>().force;
            hitbysomething(AngleOfVector(tempy.gameObject.GetComponent<PlayerFinal>().velocityX, tempy.gameObject.GetComponent<PlayerFinal>().velocityY), tempy.gameObject.GetComponent<PlayerFinal>().force);
            tempy.gameObject.GetComponent<PlayerFinal>().hitbysomething(AngleOfVector(tempy.gameObject.GetComponent<PlayerFinal>().velocityX*-1 , tempy.gameObject.GetComponent<PlayerFinal>().velocityY*-1), tempy.gameObject.GetComponent<PlayerFinal>().force*2);
           // Debug.Log("HAVE YOU ACTUALLY HIT");
        }
        if(collision.gameObject.tag=="lava")
        {
            alive = false;
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "circle")
        {
            //Destroy(this.gameObject);
            alive = false;
            COllidery.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "outty")
        {
            alive = false;
        }
    }
    void CheckIfAlive()
    {
        if(alive!=true)
        {
            Hitty.SetRounds(whatAmI);
            alive = true;
            spawn3();
            player2.spawn3();
        }
    }
    // Update is called once per frame
    void Update () {
        input();
        movement();
       
    }
    void FixedUpdate()
    {
        CheckIfAlive();
    }
}
