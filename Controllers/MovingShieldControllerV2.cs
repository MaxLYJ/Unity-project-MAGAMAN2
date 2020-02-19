using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShieldControllerV2 : MonoBehaviour {
    public float speed = 3.0f;
    public Bounds bounds;
    public float touchingRightPointTime = 0;
    public float touchingLeftPointTime = 0;

    protected float currentSpeed = 0f;
    // Use this for initialization
    void Start () {
        Vector2 pos = transform.position;

        currentSpeed = speed;
        GetComponentInChildren<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update () {
        float dt = Time.deltaTime;
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        BoxCollider2D cld = GetComponentInChildren<BoxCollider2D>();
        bounds = new Bounds(Vector3.zero, cld.size);
        bool isTouchingRightPoint = false;
        Collider2D obj = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("RightPoint"));
        if (obj != null)
        {
            isTouchingRightPoint = true;
        }

        if (isTouchingRightPoint)
        {
            if (touchingRightPointTime < 5)
            {
                currentSpeed = 0.0f;
                touchingRightPointTime += dt;
                //Debug.Log(touchingRightPointTime);
            }
            else
            {
                sr.flipX = false;
                currentSpeed = -speed;
                touchingRightPointTime = 0;
                //Debug.Log("reset");
                //Debug.Log(touchingRightPointTime);
            }
        }

        bool isTouchingLeftPoint = false;
        Collider2D obj2 = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("LeftPoint"));
        if (obj2 != null)
        {
            isTouchingLeftPoint = true;
        }

        if (isTouchingLeftPoint)
        {
            if (touchingLeftPointTime < 5)
            {
                currentSpeed = 0.0f;
                touchingLeftPointTime += dt;
            }
            else
            {
                sr.flipX = true;
                currentSpeed = speed;
                touchingLeftPointTime = 0;
            }
        }

        transform.Translate(new Vector3( currentSpeed * dt, 0, 0));
        //Vector3 pos = transform.position;
        //pos.x = pos.x + currentSpeed * dt;
        //transform.position = pos;

    }
}
