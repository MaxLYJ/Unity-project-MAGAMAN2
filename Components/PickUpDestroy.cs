using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDestroy : MonoBehaviour {

    public float HealAmount = 0f;
    public AudioClip Refilsound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponentInParent<Health>();
        if (collision.gameObject.GetComponentInParent<Megaman>() != null && health)
        {
            Debug.Log("GetHit");
            Time.timeScale = 0f;
            for (int i = 0; i < HealAmount; i++)
            {
                if (health.health < health.maxHealth)
                {
                    AudioUtil.PlayOneOffAt(transform, Refilsound);
                    health.AddHealth(1f);
                    yield return StartCoroutine(waitUntilRefil(0.25f));
                }
            }
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
    IEnumerator waitUntilRefil(float Seconds)
    {
        yield return new WaitForSecondsRealtime(Seconds);
    }

}
