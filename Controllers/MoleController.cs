using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour {
    public float speed = 1.0f;
    public Bounds bounds;
    public bool contactSlowdown = true;
    // Use this for initialization
    void Start () {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        Vector2 pos = transform.position;
        GameObject megaman = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = megaman.transform.position;
        Vector2 difference = pos - playerPosition;

        BoxCollider2D cld = GetComponentInChildren<BoxCollider2D>();
        bounds = new Bounds(Vector3.zero, cld.size);
        if (difference.y > 0.0f)
        {
            speed = -speed;
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }

	}
	
	// Update is called once per frame
	void Update () {
        

        float dt = Time.deltaTime;
        float currentspeed = speed;
        bool isTouchingFloor = false;
        Collider2D obj = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("Default"));
        if (contactSlowdown == true)
        {
            if (obj != null)
            {
                isTouchingFloor = true;
            }

            if (isTouchingFloor)
            {
                currentspeed = speed * .5f;
            }
        }
        else
        {

        }

        Vector3 pos = transform.position;
        pos.y = pos.y + currentspeed * dt;
        transform.position = pos;
	}
}
