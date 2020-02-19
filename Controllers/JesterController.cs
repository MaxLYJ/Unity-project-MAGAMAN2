using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterController : MonoBehaviour {
    public float speed, jumpVelocity;
    public Bounds bounds;
    private float curspeed;
    public JesterColliderController gearCollider;
    public GearController moveRight;
    public float jumpTime = 3f;

    // Use this for initialization
    void Start () {
        curspeed = speed;

	}
	
	// Update is called once per frame
	void Update () {
        bool isTouchingJC = false;
        bool jumpTime0 = false;
        bool isTouchingGear = false;
        BoxCollider2D cld = GetComponent<BoxCollider2D>();
        bounds = new Bounds(Vector3.zero, cld.size);
        Collider2D obj = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("JesterJump"));
        Collider2D obj2 = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("EnemyBul"));

        if ( obj != null)
        {
            isTouchingJC = true;
        }

        if(obj2 != null)
        {
            isTouchingGear = true;
        }
      //  Debug.Log(isTouchingGear);


        if(isTouchingJC && jumpTime > 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;

            jumpTime = jumpTime - 1f;

        }
        else if (jumpTime <=0)
        {
            isTouchingJC = false;
            jumpTime0 = true;
        }
        //


        //
        if (jumpTime0 && gearCollider != null)
        {

            gearCollider.DropMe();
            jumpTime0 = false;
        }

        if (isTouchingGear)
        {
            moveRight.bodyType.bodyType = RigidbodyType2D.Dynamic;
            transform.Translate(new Vector3(curspeed * Time.deltaTime, 0, 0));
            moveRight.moveRight();
            moveRight.AssignJester(this.gameObject);
        }

    }

}
