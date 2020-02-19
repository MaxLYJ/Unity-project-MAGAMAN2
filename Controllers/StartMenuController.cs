using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour {
    public float DelayTime = 2f;
    public GameObject Text;
    public AudioSource MusicSource;
    public AudioClip MusicClip;
    // Use this for initialization
    private bool InputStart = false;
	void Start () {
        MusicSource.clip = MusicClip;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Joysticks_Start") || Input.GetButtonDown("Submit"))
        {
            InputStart = true;
            MusicSource.Play();
        }
        if (InputStart)
        {
            if(DelayTime > 0)
            {
            DelayTime -= Time.deltaTime;
            GameObject.Destroy(Text);
            }
            else
            {
            SceneManager.LoadScene("LevelSelect");

            }
        }
        else
        {
            
        }
	}
}
