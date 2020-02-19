using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    //public float i = 3f;
   // public bool ismetalmandead = false;
    public float DelayTime = 4f; 
    public int lives;
    public int maxLives;
    public int maxTanks;
    public int eTanks;
    private static GameController gcInstance;
    // Use this for initialization
    void Awake () {
        if (gcInstance == null)
        {
            gcInstance = this;
            lives = maxLives;
        }
        else
        {
            DelayTime = gcInstance.DelayTime;
            lives = gcInstance.lives;
            maxLives = gcInstance.maxLives;
            maxTanks = gcInstance.maxTanks;
            eTanks = gcInstance.eTanks;
            Object.Destroy(gcInstance.gameObject);
            gcInstance = this;
        }
        DontDestroyOnLoad(this.gameObject); 
    }

    public void onDeath()
    {
        StartCoroutine(updateLive());
    }

    IEnumerator updateLive()
    {
        lives -= 1;
        yield return new WaitForSeconds(DelayTime);
        if (lives < 0)
        {
            lives = maxLives;
            eTanks = 0;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("MetalManTest");
        }
    }

    public void updateTanks(int value)
    {
        eTanks += value;
        if (eTanks > maxTanks)
        {
            eTanks = maxTanks;
        }
        if (eTanks < 0)
        {
            eTanks = 0;
        }
    }

    public void resetAll()
    {
        lives = maxLives;
        eTanks = 0;
    }

    public int getLives()
    {
        return lives;
    }

    public int getTanks()
    {
        return eTanks;
    }



  void Update()
    {
        // if (metalman == null)
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
        //       // Debug.Log("111");
        //    }
        //}
        //Debug.Log(i);
        //Debug.Log(metalman);
        //Debug.Log(ismetalmandead);
    }
}
