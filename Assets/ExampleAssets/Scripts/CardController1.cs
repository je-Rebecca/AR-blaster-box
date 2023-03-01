using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class CardController1 : MonoBehaviour
{
    private ARRaycastManager raycastManager; 

    private GameObject spawnedObject;

    //storage to select and delete.. 
    private List<GameObject> placedPrefabList = new List<GameObject>();

    //max number of obj 
    [SerializeField]
    private int maxPrefabCount = 0; 
    //count how many 
    private int placePrefabCount; 
    
    // indicator,배치 
    [SerializeField]
    private GameObject PlacementIndicator; 
    [SerializeField]
    private GameObject arObjectToSpawn;

    private Pose PlacementPose;
    private bool PlacementPoseIsValid = false; 
    private bool PlacementFunctionActive = false; 

    // 큰 카드 닫는 용도 
    [SerializeField]
    private Button closebtn;
    //using UnityEngine.UI; 써야지 버튼 인식함 


     [SerializeField]
    private Button PlacementButton; 


    [SerializeField]
    private GameObject BigImagePanel;

   
    [SerializeField]
    private GameObject placeablePrefab;
    
    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

     
    // Start is called before the first frame update
    private void Awake()
    {
        //raycastManager =GetComponent<ARRaycastManager>();
        raycastManager =FindObjectOfType<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        
        if(Input.GetTouch(0).phase == TouchPhase.Began){
            touchPosition = Input.GetTouch(0).position;
            return true; 
        }
        touchPosition =default; 
        return false; 
    }
  
  
   

    /*
     void Update()
    {
       
         if(spawnedObject==null && PlacementPoseIsValid && PlacementFunctionActive ==true && Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }
        UpdatePlacmentPose();
        UpdatePlacementIndicator(); 
    }

     public void ThumbCardActive()
    {
        BigImagePanel.SetActive(true);
    }

     public void ClickCloseButton(){
            BigImagePanel.SetActive(false);
           
     }

       public void PlacementButtonClicked(){
         ClickCloseButton();
          PlacementFunctionActive = true; 
        
           
     }

       void UpdatePlacementIndicator() 
      {
           if(spawnedObject == null & PlacementPoseIsValid && PlacementFunctionActive)
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
        
        //  var screenCenter= Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
          var hits = new List<ARRaycastHit>(); 
          raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
          
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
   */
    
    
     // Update is called once per frame
    
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition)){

            return;
        }
        //AvatarWithinPoly = PlaneWithinPolygon
        if(raycastManager.Raycast(touchPosition, s_hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose =s_hits[0].pose; 
               if(placePrefabCount < maxPrefabCount)
               {
               ThumbCardActive();
             // SpawnPrefab(hitPose);
               }
            
        }
    }

      public void ThumbCardActive()
    {
        BigImagePanel.SetActive(true);
    }
    
    public void SetPrefabType(GameObject prefabType)
    {
        placeablePrefab = prefabType; 
    }
   
    private void SpawnPrefab(Pose hitPose)
    {
          spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
                placedPrefabList.Add(spawnedObject);
                placePrefabCount++;
    }
    
}
