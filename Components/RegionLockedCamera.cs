using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionLockedCamera : MonoBehaviour 
{
   public GameObject objectToFollow; 
   public AnimationCurve lerpCurve = AnimationCurve.Linear( 0, 0, 1, 1 ); 

   private CameraRegion[] cameraRegions; 

   void Start() 
   {
	   cameraRegions = GameObject.FindObjectsOfType<CameraRegion>(); 
   }

   CameraRegion FindRegionForPoint( Vector2 position ) 
   {
      for (int i = 0; i < cameraRegions.Length; ++i) {
         CameraRegion region = cameraRegions[i]; 
         Bounds b = region.GetWorldBounds(); 

         if ((position.x >= b.min.x) 
             && (position.x <= b.max.x) 
             && (position.y >= b.min.y)
             && (position.y <= b.max.y)) {

            return region; 
         }
      }

      return null; 
   }

   float FitWithinAxis( float center, 
      float fitMin, float fitMax, 
      float containerMin, float containerMax )
   {
      // case 1: already in it
      if ( (fitMin >= containerMin) && (fitMax <= containerMax) ) {
         return center; 
      
      // case 2: too big 
      } else if ( (fitMax - fitMin) >= (containerMax - containerMin) ) {
         return 0.5f * (containerMax + containerMin); 

      // case 3: needs to shift slightly
      } else {
         // case 3.1:  I'm too far left
         if (fitMin < containerMin) {
            return center + (containerMin - fitMin); 

          // case 3.2:  I'm too far right
         } else { // fitMax > containerMax
            return center + (containerMax - fitMax); 
         }
      }
   }

   // FindRegionForPoint
   // GetWorldBounds for CameraRegion2
   // FitWithinBox for Bounds
   Bounds FitWithinBoundsXY( Bounds toFit, Bounds container )
   {
      Vector3 newCenter = toFit.center; 

      newCenter.x = FitWithinAxis( toFit.center.x, 
         toFit.min.x, toFit.max.x,
         container.min.x, container.max.x );
      
      newCenter.y = FitWithinAxis( toFit.center.y, 
         toFit.min.y, toFit.max.y,
         container.min.y, container.max.y );

      return new Bounds( newCenter, toFit.size ); 
   }


   void Update() 
   {
      // which region is my target in (that's where I want look)
	   Vector3 targetPos = objectToFollow.transform.position;  

      // Which region is my part of?
      CameraRegion currentRegion = FindRegionForPoint( targetPos ); 

      if (currentRegion != null) {
         // put where I want it
         Bounds cameraBounds = Camera.main.GetWorldBounds(); 
         cameraBounds.center = new Vector3( targetPos.x, targetPos.y, cameraBounds.center.z ); 

         // nudge back if need be
         cameraBounds = FitWithinBoundsXY( cameraBounds, currentRegion.GetWorldBounds() ); 

         Vector3 finalPos = new Vector3( cameraBounds.center.x, cameraBounds.center.y, Camera.main.transform.position.z ); 
         Camera.main.transform.position = finalPos; 

      } else {
         // don't do anything... might want to center palyer.. or kill player... yaknow.. whatever...
      }
   }
}
