using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherController : MonoBehaviour {
    public float speed;
    public Bounds bounds,bounds2;
    public float touchingRightPointTime = 0;
    public float touchingLeftPointTime = 0;
    protected float currentSpeed = 0f;

    // Use this for initialization
    void Start () {
        Vector2 pos = transform.position;

        currentSpeed = speed;

    }

    // Update is called once per frame
    void Update () {
        bool isTouchingLeftPoint = false;
        float dt = Time.deltaTime;
        BoxCollider2D cld = GetComponentInChildren<BoxCollider2D>();
        CapsuleCollider2D ccld = GetComponent<CapsuleCollider2D>();
        bounds = new Bounds(Vector3.zero, cld.size);
        bounds2 = new Bounds(Vector3.zero, ccld.size);
        Collider2D obj3 = Physics2D.OverlapBox(transform.position, bounds2.size, 0.0f, LayerMask.GetMask("PlayerPhyx"));
            bool isTouchingRightPoint = false;
            Collider2D obj = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("RightPoint"));


        if (obj != null)
            {
                isTouchingRightPoint = true;
            }


        if (isTouchingRightPoint)
            {
                if (touchingRightPointTime < 2)
                {
                    currentSpeed = 0.0f;
                    touchingRightPointTime += dt;
                }
                else
                {
                    currentSpeed = -speed * 0.5f;
                    touchingRightPointTime = 0;
                    transform.Translate(new Vector3(0, currentSpeed * dt, 0));



                if (isTouchingLeftPoint)
                {
                    if (touchingLeftPointTime < 2)
                    {
                        currentSpeed = 0.0f;
                        touchingLeftPointTime += dt;
                    }
                    else
                    {
                        currentSpeed = speed;
                        touchingLeftPointTime = 0;
                    }
                }


            }
        }

        if (obj3 != null)
        {
            Collider2D obj2 = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("LeftPoint"));

            if (obj2 != null)
            {
                isTouchingLeftPoint = true;
            }

            if (isTouchingLeftPoint)
            {
                if (touchingLeftPointTime < 2)
                {
                    currentSpeed = 0.0f;
                    touchingLeftPointTime += dt;
                }
                else
                {
                    currentSpeed = speed;
                    touchingLeftPointTime = 0;
                }
            }


            transform.Translate(new Vector3(0, currentSpeed * dt, 0));

        }
    }
}
