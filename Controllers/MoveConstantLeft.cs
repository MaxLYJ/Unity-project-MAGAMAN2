using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstantLeft : MonoBehaviour
{
public float speed = .1f;
 
	// Use this for initialization
	void Start ()
    {
       
        
	}

    // Update is called once per frame
void Update()
    {

        Vector3 pos = transform.position;
        float dt = Time.deltaTime;
        pos.x = pos.x + speed * dt;
        transform.position = pos;

    }  
}
