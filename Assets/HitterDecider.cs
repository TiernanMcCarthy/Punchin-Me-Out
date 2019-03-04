using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitterDecider : MonoBehaviour {
    public string WhoHitWho;
    public string WhoWon;
    public byte Player1Rounds;
    private BaseTimer timey;
    public byte Player2Rounds;
    public Text Score1;
    public Text Score2;
    public Transform Level;
    public CircleCalculation circle;
    public GameObject currentLevel;
    private MoveCamera cammy;
    public GameObject LevelExample;
    public bool GameOver = false;
	// Use this for initialization
	void Start () {
        circle = FindObjectOfType<CircleCalculation>();
        timey = FindObjectOfType<BaseTimer>();
        cammy = FindObjectOfType<MoveCamera>();
	}
    void FixedUpdate()
    {
        if(GameOver==true)
        {
            //Jump to a new scene
            //Destroy(currentLevel);
            //  GameObject temp;
            //  temp = (GameObject)Instantiate(LevelExample, Level.transform.position, Quaternion.identity);
            // currentLevel = temp.gameObject;
            //circle.restartTime();
            //timey.Reset();
           // GameOver = false;
            //Debug.Log("YES?");

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void SetRounds(string Winner)
    {
        WhoWon = Winner;
        //Debug.Log("hello");
        if(WhoWon=="player1")
        {
            Player2Rounds += 1;
        }
        else if(WhoWon=="player2")
        {
            Player1Rounds += 1;
        }
        timey.Reset();
        if(Player1Rounds==3)
        {
            GameOver = true;
            cammy.Movey(-94.51f, -13.49f);
        }
        else if(Player2Rounds==3)
        {
            GameOver = true;
            cammy.Movey(-94.95f, 13.07f);
        }
        Score1.text = Player1Rounds.ToString();
        Score2.text = Player2Rounds.ToString();
        // GameOver = true;

    }
}
