using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringerController : MonoBehaviour {
    public LayerMask enemyMask;
    public LayerMask watchPlayer;
    public float speed = 1f;
    public float rush = 10f;
    private float curspeed;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;
    public Animator m_Animator;
    public Bounds bounds;
    private float delayTime = 2f;

    private bool isSpring = false;

    // Use this for initialization





    void Start () {
        GetComponentInChildren<SpriteRenderer>().flipX = false;
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponentInChildren<SpriteRenderer>().bounds.extents.x;
        myHeight = this.GetComponentInChildren<SpriteRenderer>().bounds.extents.y;

    }

    // Update is called once per frame
    void FixedUpdate ()
    {


        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        BoxCollider2D cld = GetComponentInChildren<BoxCollider2D>();

        //Debug.Log(sr.flipX);

        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);

        Vector2 lineCastPosRight = myTrans.position + myTrans.right * myWidth;
        Debug.DrawLine(lineCastPosRight, lineCastPosRight + Vector2.down);


        Debug.DrawLine(lineCastPos + myTrans.up.toVector2() * myHeight, 
            lineCastPos - myTrans.right.toVector2() * 0.25f + myTrans.up.toVector2() * myHeight);

        Debug.DrawLine(lineCastPosRight + myTrans.up.toVector2() * myHeight, 
            lineCastPosRight + myTrans.right.toVector2() * 0.25f + myTrans.up.toVector2() * myHeight);
      
        //RaycastHit2D hit = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        //Debug.Log(hit.collider.name);

        bool isGroundedLeft = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        bool isGroundedRight = Physics2D.Linecast(lineCastPosRight, lineCastPosRight + Vector2.down, enemyMask);

        bool isBlockedRight = Physics2D.Linecast(lineCastPosRight + myTrans.up.toVector2() * myHeight,
            lineCastPosRight + myTrans.right.toVector2() * 0.25f + myTrans.up.toVector2() * myHeight,    enemyMask);

        bool isBlockedLeft = Physics2D.Linecast(lineCastPos + myTrans.up.toVector2() * myHeight,
            lineCastPos - myTrans.right.toVector2() * 0.25f + myTrans.up.toVector2() * myHeight,    enemyMask);

        bool isWatching = Physics2D.Linecast(lineCastPosRight + myTrans.right.toVector2() * 10f + myTrans.up.toVector2() * myHeight * 0.5f, 
            lineCastPos - myTrans.right.toVector2() * 10f + myTrans.up.toVector2() * myHeight * 0.5f, watchPlayer);

        Debug.DrawLine(lineCastPosRight + myTrans.right.toVector2() * 10f + myTrans.up.toVector2() * myHeight * 0.5f,
            lineCastPos - myTrans.right.toVector2() * 10f + myTrans.up.toVector2() * myHeight * 0.5f);

        if (!isGroundedLeft || isBlockedLeft)
        {
           //  Debug.Log("left block");
           // Debug.Log("<<" + sr.flipX);
            curspeed = speed;
            sr.flipX = false;
           // Debug.Log(">>" + sr.flipX);
        }
        else if (!isGroundedRight || isBlockedRight)
        {
           // Debug.Log("right block");
           // Debug.Log("<<" + sr.flipX);
            curspeed = -speed;
            sr.flipX = true;
           // Debug.Log(">>" + sr.flipX);
        }

        if (isWatching)
        {
            if(curspeed > 0)
            {
                curspeed = rush;

            }
            else
            {
                curspeed = -rush;

            }
        }
        else if (!isWatching)
        {
            if (curspeed > 0)
            {
                curspeed = speed;

            }
            else
            {
                curspeed = -speed;

            }
        }




    bounds = new Bounds(Vector3.zero, cld.size);

    Collider2D obj = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("PlayerPhyx"));

        if (obj != null )
        {
            isSpring = true;
            m_Animator.Play("SrpingerSpring");
            curspeed = 0f;
        }
        if (!isSpring)
            transform.Translate(new Vector3(curspeed * Time.deltaTime, 0, 0));

    }

    public void OnAnimationEnd()
    {
        Debug.Log("animation end invoked");
        isSpring = false;
    }

}
