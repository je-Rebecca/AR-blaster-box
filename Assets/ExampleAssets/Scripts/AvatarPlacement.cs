using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AvatarPlacement : MonoBehaviour
{
   public GameObject arObjectToSpawn; 
   public GameObject PlacementIndicator; 
   private GameObject spawnedObject; 
   private Pose PlacementPose; 
   private ARRaycastManager arRaycastManager; 
   private bool PlacementPoseIsValid = false; 


    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
         if(spawnedObject==null && PlacementPoseIsValid && Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }
        UpdatePlacmentPose();
        UpdatePlacementIndicator(); 
    }


     void UpdatePlacementIndicator() 
      {
           if(spawnedObject == null & PlacementPoseIsValid )
           {
                  PlacementIndicator.SetActive(true);
                  PlacementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);  
           }
           else
           {
                  PlacementIndicator.SetActive(false);
           }
     }

       void UpdatePlacmentPose()
     {
        var screenCenter= Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        
         var hits = new List<ARRaycastHit>(); 
          arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
          
          PlacementPoseIsValid = hits.Count >0; 
          if(PlacementPoseIsValid)
          {
                PlacementPose = hits[0].pose; 
          }
     }


       void ARPlaceObject()
    {
         spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }



}
