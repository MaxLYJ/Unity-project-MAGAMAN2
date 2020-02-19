using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSpawner : MonoBehaviour {


    public GameObject spawner;
    public int timer;






	// Use this for initialization
	void Start () {
        StartCoroutine(ShowObject());
	}
	

    IEnumerator ShowObject()
    {
        yield return new WaitForSeconds(timer);
        spawner.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
