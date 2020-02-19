using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {
    public float i = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (i > 0)
        {
            i = i - 1f * Time.deltaTime;
        }
        else if (i <= 0)
        {
            SceneManager.LoadScene("LevelSelect");
        }
	}
}
