using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MetalManLevelContorller : MonoBehaviour {
    public GameObject megaman;
    private GameObject bgm;
    public int lives;
    public int maxLives = 3;
    public int maxTanks;
    public int eTanks;
    private static GameObject gcInstance;
    public GameController liveNumber;
    // Use this for initialization
    void Start ()
    {
        megaman = GameObject.FindGameObjectWithTag("Player");
        bgm = GameObject.FindGameObjectWithTag("BGM");
	}
	
	// Update is called once per frame
	void Update () {

        //if (metalman == null)
        //{
        //    ismetalmandead = true;
        //}
        //if (ismetalmandead)
        //{
        //    if (i > 0)
        //    {
        //        i = i - 1f * Time.deltaTime;
        //    }
        //    else if (i <= 0 && ismetalmandead == true)
        //    {
        //        ismetalmandead = false;
        //        SceneManager.LoadScene("MainMenu");
        //        // Debug.Log("111");
        //    }
        //}
        //Debug.Log(i);
        //Debug.Log(metalman);
        //Debug.Log(ismetalmandead);
    }


}
