using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaManTime : MonoBehaviour {
    private Health playerhealth;
    public float DelayTime = 2f;
    // Use this for initialization
    void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<Health>();
        
	}

    public void onDeathHandler(float dmg)
    {
        if(playerhealth.health == 0)
        {
            StartCoroutine(countDown(DelayTime));
        }
    }

    IEnumerator countDown(float time)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
        yield return null;
    }
}
