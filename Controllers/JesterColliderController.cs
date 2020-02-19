using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterColliderController : MonoBehaviour {
    //public float jumpTime=3f;
    //public Bounds bounds;
    // Use this for initialization


    public RigidbodyType2D bodyType;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        BoxCollider2D cld = GetComponent<BoxCollider2D>();
        bounds = new Bounds(Vector3.zero, cld.size);
        Collider2D obj = Physics2D.OverlapBox(transform.position, bounds.size, 0.0f, LayerMask.GetMask("EnemyPhyx"));
        bool istouchingJ = false;
        if (obj != null)
        {
            istouchingJ = true;
        }
        Debug.Log(istouchingJ);
        Debug.Log(obj.gameObject.name);
        if ( istouchingJ && jumpTime > 0)
        {
            jumpTime = jumpTime - 1f;
            Debug.Log(jumpTime);
        }
        else if (jumpTime <= 0)
        {
            
        }
        */



    }
    public void DropMe()
    {
        Destroy(gameObject);
    }
}
