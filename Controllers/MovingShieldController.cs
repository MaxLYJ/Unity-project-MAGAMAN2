using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShieldController : MonoBehaviour {
    public float speed = -1.0f;
    public bool moveManhattan = false;
    public string targetTagR = "RightPoint";
    public string targetTagL = "LeftPoint";
    private GameObject rightPoint;
    private GameObject leftPoint;
    public Bounds bounds;
    public int touchingRightPointTime = 0;

    void Start () {
        rightPoint = GameObject.FindGameObjectWithTag(targetTagR);
        leftPoint = GameObject.FindGameObjectWithTag(targetTagL);
        Vector2 pos = transform.position;
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        Vector2 rightPointPosition = rightPoint.transform.position;
        Vector2 difference = pos - rightPointPosition;

        BoxCollider2D cld = GetComponentInChildren<BoxCollider2D>();
        bounds = new Bounds(Vector3.zero, cld.size);
        if (difference.x > 0.0f)
        {
            speed = -speed;
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

    }

    // Update is called once per frame
    void Update () {
        Vector2 target = GetTarget();
        Vector2 diff = target - transform.position.XY();
        Vector2 dir = diff.normalized;
        Vector2 moveDir = dir;

        float dt = Time.deltaTime;
        float currentSpeed = speed;
        bool isTouchingRightPoint = false;
        Collider2D obj = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("RightPoint"));
        if(obj != null)
        {
            isTouchingRightPoint = true;
        }

        if (isTouchingRightPoint)
        {
            if (touchingRightPointTime < 5)
            {
                currentSpeed = 0.0f;
                touchingRightPointTime++;
            }
            else
            {
                currentSpeed = -speed;
            }
        }

        if (moveDir == Vector2.zero)
        {
            return;
        }

        if (moveManhattan)
        {
            if(Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
            {
                moveDir.x /= Mathf.Abs(moveDir.x);
                moveDir.y = 0.0f;
            }
            else
            {
                moveDir.y /= Mathf.Abs(moveDir.y);
                moveDir.x = 0.0f;
            }
        }

        Vector2 disp = moveDir * currentSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(disp.x, disp.y, 0.0f);
    }

    Vector2 GetTarget()
    {
        if(rightPoint  == null)
        {
            return Vector2.zero;
        }
        else
        {
            return rightPoint.transform.position;
        }
        /*
        if (leftPoint == null)
        {
            return Vector2.zero;
        }
        else
        {
            return leftPoint.transform.position;
        }
        */
    }
}
