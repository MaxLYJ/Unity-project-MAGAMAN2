using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanEyesBlink : MonoBehaviour {
    float randomNumber;
    public bool EyesBlink = true;
    public Animator animator;

    // Use this for initialization
    void Start () {
        getRandomNumber();
    }
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;

        if (randomNumber >= 0 && EyesBlink == true)
        {
            randomNumber -= dt;
            animator.SetBool("Blink", false);

        }
        else
        {
            animator.SetBool("Blink", true);
            getRandomNumber();
         
        }
	}

    void getRandomNumber()
    {
        randomNumber = Random.Range(1f, 5f);
    }
}
