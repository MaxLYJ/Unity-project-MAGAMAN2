using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraRegion2 : MonoBehaviour 
{
   public Bounds GetWorldBounds()
   {
      BoxCollider2D bc = GetComponent<BoxCollider2D>(); 
      return bc.bounds; 
   }
}
