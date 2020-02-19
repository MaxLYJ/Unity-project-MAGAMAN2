using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class CameraRegion : MonoBehaviour {


    public Bounds GetWorldBounds()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        return bc.bounds;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
