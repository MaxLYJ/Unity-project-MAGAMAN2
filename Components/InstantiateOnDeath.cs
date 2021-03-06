﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

[RequireComponent(typeof(Health))]
public class InstantiateOnDeath : MonoBehaviour
{
    private float randomNumber;
    public GameObject prefabToSpawn;
    public GameObject healthPickupFor10ToSpawn;
    public GameObject healthPickupFor2ToSpawn;
    public uint spawnCount = 1;
    public Transform spawnLocation; // optional - otherwise it'll spawn locally; 
    public bool spawnAsChild = false;

    void Start()
    {
        getRandomNumber();

        Health h = GetComponent<Health>();
        h.onDeath.AddListener(OnDeath);

        // set this up - so I can just assume spawn location is always non-null; 
        if (spawnLocation == null)
        {
            spawnAsChild = false;
            spawnLocation = transform;
        }
    }



    void OnDeath()
    {
        if (prefabToSpawn == null)
        {
            return;
        }

        // set this up - so I can just assume spawn location is always non-null; 
        if (spawnLocation == null)
        {
            spawnAsChild = false;
            spawnLocation = transform;
        }

        for (uint i = 0; i < spawnCount; ++i)
        {
            if (spawnAsChild)
            {
                GameObject.Instantiate(prefabToSpawn, spawnLocation);
                if (randomNumber < 0.66f)
                {
                    GameObject.Instantiate(healthPickupFor10ToSpawn, spawnLocation);
                }
                if (randomNumber > 0.66f)
                {
                    GameObject.Instantiate(healthPickupFor2ToSpawn, spawnLocation);

                }
            }
            else
            {
                GameObject.Instantiate(prefabToSpawn, spawnLocation.position, spawnLocation.rotation);
                if (randomNumber < 0.66f && randomNumber > 0.33f)
                {
                    GameObject.Instantiate(healthPickupFor10ToSpawn, spawnLocation.position, spawnLocation.rotation);
                }

                if (randomNumber > 0.66f)
                {
                    GameObject.Instantiate(healthPickupFor2ToSpawn, spawnLocation.position, spawnLocation.rotation);
                }
            }
        }
    }

    void getRandomNumber()
    {
        randomNumber = Random.Range(0f, 1f);
    }
}