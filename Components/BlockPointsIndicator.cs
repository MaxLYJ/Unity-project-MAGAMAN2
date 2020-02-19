using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPointsIndicator : MonoBehaviour {
    public GameObject left;
    public GameObject right;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(left.transform.position, right.transform.position);
    }
}
