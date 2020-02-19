using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eTank : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponentInParent<Health>();
        if (collision.gameObject.GetComponentInParent<Megaman>() != null && health)
        {
            GameObject myGameController;
            myGameController = GameObject.Find("LevelController");
            myGameController.GetComponent<GameController>().updateTanks(1);
            yield return StartCoroutine(waitUntilRefil(0f));

            Destroy(gameObject);
        }



    }
    IEnumerator waitUntilRefil(float Seconds)
    {
        yield return new WaitForSecondsRealtime(Seconds);
    }



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.root.gameObject.tag == "Player")
    //    {
    //        GameObject myGameController;
    //        myGameController = GameObject.Find("LevelController");
    //        myGameController.GetComponent<GameController>().updateTanks(1);
    //        Destroy(this.gameObject);
    //    }
    //}
}
