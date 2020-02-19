using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindMetalMan : MonoBehaviour {
    public float i = 3f;
    public GameObject metalman;
    public bool ismetalmandead = false;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (metalman == null)
        {
            ismetalmandead = true;
        }
        if (ismetalmandead)
        {
            if (i > 0)
            {
                i = i - 1f * Time.deltaTime;
            }
            else if (i <= 0 && ismetalmandead == true)
            {
                ismetalmandead = false;
                SceneManager.LoadScene("MainMenu");
                // Debug.Log("111");
            }
        }
        //Debug.Log(i);
        //Debug.Log(metalman);
        //Debug.Log(ismetalmandead);

    }
}
