using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetalMan_Controller : MonoBehaviour {
    //public float i = 3f;
    //public GameObject metalman;
    //public bool ismetalmandead = false;

    public float proximity;
    public float sideJumpProximity;
    bool activated;
    bool fightStarted;
    bool leftSide;
    public bool attacking;
    GameObject megaman;
    GameObject metalMan;
    int LJT; //last jump type
    int sawsThrown;
    public bool isMetalManDead = false;
    //private Animator animator;
    private int jumping_param;

    public GameObject saw_GO;

    float totalTime;
    float totalTime2;
    public float attackInterval;
    public float sawInterval;
    GroundCheck groundCheck;
	// Use this for initialization
	void Start () {

        
        //jumping_param = Animator.StringToHash("jumping");
        activated = false;
        fightStarted = false;
        megaman = GameObject.Find("megaman");
        foreach (Transform child in transform)
        {
            metalMan = child.gameObject;
        }

        metalMan.GetComponent<Health>().onDeath.AddListener(OnDeath);
        totalTime = 0;
        totalTime2 = 0;
        attacking = false;
        leftSide = false;
        sawsThrown = 0;

	}
	
	// Update is called once per frame
	void Update () {
        checkProximity();
        if (fightStarted == true)
        {
            fightBehavior();
        }

        //if (metalman == null)
        //{
        //    ismetalmandead = true;
        //}
        //if (ismetalmandead)
        //{
        //    if (i > 0)
        //    {
        //        i = i - 1f * Time.deltaTime;
        //    }
        //    else if (i <= 0 && ismetalmandead == true)
        //    {
        //        ismetalmandead = false;
        //        SceneManager.LoadScene("MainMenu");
        //        // Debug.Log("111");
        //    }
        //}
        //Debug.Log(i);
        //Debug.Log(metalman);
        //Debug.Log(ismetalmandead);

    }

    void checkProximity()
    {
        if (activated == false)
        {
            if (Mathf.Abs(megaman.transform.position.x - this.transform.position.x) < proximity)
            {
                spawnMe();
                StartCoroutine(delayFightStart());
                megaman.GetComponent<Megaman>().canInput = false;
                activated = true;
            }
        }
    }

    bool checkFightingProximity()
    {
        if (Mathf.Abs(megaman.transform.position.x - metalMan.transform.position.x) < sideJumpProximity)
        {
            return true;
        }
        return false;
    }

    void spawnMe()
    {
        metalMan.SetActive(true);
        groundCheck = this.GetComponentInChildren<GroundCheck>();
       // animator = GetComponentInChildren<Animator>();
    }

    void fightBehavior()
    {
        totalTime += Time.deltaTime;
        totalTime2 += Time.deltaTime;
        int jumpType = Random.Range(0, 3);
        if (totalTime > attackInterval)
        {
            Debug.Log("JUMP~ " + jumpType);
            totalTime = 0;
            if (checkFightingProximity()) //if hes close when its our time to jump...
            {
                jump4();
                LJT = 3;
                return;
            }

            if (jumpType == 0)
            {
                jump1();
                LJT = 1;
            }
            else if (jumpType == 1)
            {
                jump2();
                LJT = 2;
            }
            else
            {
                jump3();
                LJT = 3;
            }


        }
        attackingPhase();
        stopXVel();
        
        
    }


    void stopXVel()
    {
        if (groundCheck.IsAirborn())
        {
            attacking = true;
        }

        if (attacking == true)
        {
            if (groundCheck.IsGrounded()) //we've just landed
            {
                attacking = false;
                metalMan.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                sawsThrown = 0;
            }
        }
    }
    //seperated for #saws thrown
    void jump1()
    {
        metalMan.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
    }

    void jump2()
    {
        metalMan.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 25);
    }

    void jump3()
    {
        metalMan.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30);
    }

    void jump4()
    {

        if (leftSide == false) //im not on left side -> head there
        {
            metalMan.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 30);
            leftSide = true;
            flipMe(leftSide);
        }
        else
        {
            metalMan.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 30);
            leftSide = false;
            flipMe(leftSide);
        }
        
    }

    void attackingPhase()
    {
        if (attacking == true)
        {
            if (totalTime2 > sawInterval && sawsThrown < LJT)
            {
                totalTime2 = 0;
                attack();
                sawsThrown += 1;
            }

        }
    }

    void attack()
    {
        //instantiate saw, send it flying towards megaman
        GameObject saw = GameObject.Instantiate(saw_GO);
        //TODO play anim;
        //animator.Play("MetalMan_Attack");
    }

    IEnumerator delayFightStart()
    {
        yield return new WaitForSecondsRealtime(3f);
        megaman.GetComponent<Megaman>().canInput = true;
        fightStarted = true;
        totalTime = attackInterval; //to start us off with an attack!
        yield return null;
    }

    void flipMe(bool left)
    {
        if (left)
        {
            foreach (Transform child in metalMan.transform)
            {
                if (child.name == "Visual")
                {
                    child.transform.localScale = new Vector2(-1, 1);
                }
            }
        }
        else
        {
            foreach (Transform child in metalMan.transform)
            {
                if (child.name == "Visual")
                {
                    child.transform.localScale = new Vector2(1, 1);
                }
            }
        }
    }

    void updateAnimator()
    {
        //animator.SetBool(jumping_param, attacking);
    }

    void OnDeath() //death function for METAL MAN!
    {
        
        megaman.GetComponent<Megaman>().canInput = false;
        isMetalManDead = true;
        Object.Destroy(this);

      

    }

    //IEnumerator coroutineDead()
    //{
    //    yield return new WaitForSeconds(2.0f);
    //}
}
