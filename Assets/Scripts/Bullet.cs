using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public string WhoShotme;
    public float force;
    private float damage;
    public BaseTimer timerScript;
    private float alivetime;
    private float velocityX;
    private float velocityY;
    public SpriteHolder bob;
    private Sprite texture;
    public bool original;
    private SpriteRenderer spriteR;
    // Use this for initialization
    void Start () {
        timerScript = FindObjectOfType<BaseTimer>();
        bob = FindObjectOfType<SpriteHolder>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        texture = bob.bullet;
        spriteR.sprite = texture;
    }
	public void spawn(float x,float y,float vectorangle,float spud,string WhoDoneDidIt)
    {
        original = false;
        WhoShotme = WhoDoneDidIt;
        transform.position = new Vector2(x, y);
        transform.rotation = Quaternion.Euler(0, 0, vectorangle);
        speed = spud;
        velocityX = (speed * Mathf.Cos(transform.rotation.eulerAngles.z * 0.01745f)) * Time.deltaTime;
        velocityY = (speed * Mathf.Sin(transform.rotation.eulerAngles.z * 0.01745f)) * Time.deltaTime;
        alivetime = timerScript.t;
    }
    
	// Update is called once per frame
	void Update () {
        if (timerScript.t - alivetime < 3.0f)
        {
            transform.position = new Vector2(transform.position.x + velocityX, transform.position.y + velocityY);
        }
        else if (timerScript.t - alivetime > 3.0f && original != true)
        {
            Destroy(this.gameObject);
        }
		
	}
}
