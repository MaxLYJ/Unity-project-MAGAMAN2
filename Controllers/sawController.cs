using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawController : MonoBehaviour {

    Vector3 target;
    Vector3 start;
    float speed = 10;

    GameObject megaman;
    GameObject metalMan;

    private Vector3 normalizeDirection;
    // Use this for initialization
    void Start () {

        megaman = GameObject.Find("megaman");
        metalMan = GameObject.Find("MetalMan");
        target = megaman.transform.position;
        start = metalMan.transform.position;
        this.transform.position = start;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        normalizeDirection = (target - start).normalized;
        //transform.position = Vector2.MoveTowards(transform.position, target, step);
        transform.position += normalizeDirection * speed * Time.deltaTime;
    }
}
