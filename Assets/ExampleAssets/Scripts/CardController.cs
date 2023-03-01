using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class CardController : MonoBehaviour
{
     [SerializeField]
    GameObject contentPrefab; 
    //���� �� 
    private GameObject spawnedObject;
    
    [SerializeField]
    ARRaycastManager raycastManager; 
    [SerializeField]
    GraphicRaycaster raycasterCanvas; 
    [SerializeField]
    PhysicsRaycaster raycasterUI; 
    [SerializeField]
    PhysicsRaycaster raycasterAR; 


    /*
    //storage to select and delete.. 
    private List<GameObject> placedPrefabList = new List<GameObject>();

    //max number of obj 
    [SerializeField]
    //private int maxPrefabCount = 0; 
    //count how many 
    private int placePrefabCount; 
    
    // indicator,��ġ 
    [SerializeField]
    private GameObject PlacementIndicator; 
    [SerializeField]
    private GameObject arObjectToSpawn;

    private Pose PlacementPose;
    // private bool PlacementPoseIsValid = false; 
    private bool PlacementFunctionActive = false; 

    // ū ī�� �ݴ� �뵵 
    [SerializeField]
    private Button closebtn;
    //using UnityEngine.UI; ����� ��ư �ν��� 


     [SerializeField]
    private Button PlacementButton; 


    [SerializeField]
    private GameObject BigImagePanel;
    */
   
        private void Update(){
            if(Input.GetMouseButtonDown(0) && !IsClickOverUI()){
                List<ARRaycastHit> hitPoints = new List<ARRaycastHit>(); 
                raycastManager.Raycast(Input.mousePosition,hitPoints,TrackableType.Planes);

                if(hitPoints.Count >0 ){
                    Pose pose =hitPoints[0].pose; 
                    Instantiate(contentPrefab, pose.position, pose.rotation, transform); 
                }
            }
         }

     bool IsClickOverUI(){
          PointerEventData data = new PointerEventData(EventSystem.current){
                position = Input.mousePosition
          }; 
          List<RaycastResult> results = new List<RaycastResult>();
          raycasterCanvas.Raycast(data, results); 
          raycasterUI.Raycast(data, results);
          raycasterAR.Raycast(data, results); 

          results.RemoveAll(r => r.gameObject.tag =="plane"); 

          return results.Count>0 ; 
     }




  }