using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveCamera : MonoBehaviour {
    private bool waiting = false;
    private BaseTimer timey;
    private float localtime;
    public AudioClip telporterOn;
    public AudioClip telporterOff;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        timey = FindObjectOfType<BaseTimer>();
        source = GetComponent<AudioSource>();
    }
	public void Movey(float x, float y)
    {
        transform.position = new Vector2(x, y);
        waiting = true;
        localtime = timey.t;
        source.PlayOneShot(telporterOff, 0.4f);
        source.PlayOneShot(telporterOn, 0.4f);
    }
	// Update is called once per frame
	void Update () {
		if(waiting==true)
        {
            Debug.Log(localtime - timey.t);
            if (timey.t - localtime>4.0f)
            {
                Debug.Log("WHHYYYYY");
                //Load a new scene
                SceneManager.LoadScene(0);
            }
        }
	}
}
