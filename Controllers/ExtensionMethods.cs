using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntensionMethods
{
    public static Vector2 toVector2(this Vector3 vec3)
    {
        return new Vector2(vec3.x, vec3.y);
    }
}


public class ExtensionMethods : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
