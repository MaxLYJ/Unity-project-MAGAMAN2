using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour {
    //public float speed = 3f;
    public JesterController jesterSpeed;
    private float curspeed;
    public GameObject jester;
    private float rush = -1.5f;
    public Rigidbody2D bodyType;
    

    private bool isMoving;
	// Use this for initialization
	void Start () {
        bodyType = GetComponent<Rigidbody2D>();
      //  curspeed = GetComponent<JesterController>().speed;
        curspeed = jesterSpeed.GetComponent<JesterController>().speed;

        //Debug.Log(GetComponent<JesterController>().speed);

        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {

        //moveRight();
        if (isMoving)
        {
            //print("ismoving");
            //print(jester);
            if (jester == null)
            {
                Debug.Log("decrease speed");
                curspeed = rush;
                transform.Translate(new Vector3(curspeed * Time.deltaTime * 0.5f, 0, 0));

            }
        }

    }
    
    public void AssignJester(GameObject targetJester)
    {
        jester = targetJester;
    }

    public void moveRight()
    {
        isMoving = true;
        if (jester = null)
        {
            return;
            //curspeed = rush;
            //transform.Translate(new Vector3(curspeed * Time.deltaTime , 0, 0));

        }
        else if (jester != null)
        {
            curspeed = jesterSpeed.GetComponent<JesterController>().speed;

            transform.Translate(new Vector3(curspeed * Time.deltaTime, 0, 0));
        }

        curspeed = jesterSpeed.GetComponent<JesterController>().speed;

        transform.Translate(new Vector3(curspeed * Time.deltaTime, 0, 0));

    }

    public void destroyGear()
    {
        Destroy(gameObject);
    }
}
