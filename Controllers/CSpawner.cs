using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawner : MonoBehaviour {

    public GameObject spawner;
    public int timer;
    bool isMegaClose = false;
    public GameObject player;
    private float  dif;
    private float difN;
    public bool ifJesterDie=false;

    private bool isJesterSpawned = false;

    private void Awake()
    {
        dif = 1000000;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShowObject());
        player = GameObject.FindGameObjectWithTag("Player");

    }


    IEnumerator ShowObject()
    {
        while (true)
        {
            if (dif < 5 && !isJesterSpawned)
            {
                yield return new WaitForSeconds(timer);
                spawner.SetActive(true);
                isJesterSpawned = true;
            }
            yield return null;

        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject jester = GameObject.FindGameObjectWithTag("Jester");

        float playerP = player.transform.position.x;
        float thisP = this.transform.position.x;
        dif = Mathf.Abs(thisP - playerP);


        if (jester != null)
        {
            ifJesterDie = false;

        }
        else if (jester = null)
        {
               ifJesterDie = true;


        }
        //Debug.Log(ifJesterDie);

    }

}
