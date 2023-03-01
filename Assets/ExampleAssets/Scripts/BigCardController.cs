using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BigCardController : MonoBehaviour
{
    public Button closeBtn;
    //private bool closeBtn = true; 
    [SerializeField]
    private GameObject placeButton; 

     [SerializeField]
    private GameObject BigImagePanel;

    public void clickCloseButton(){
        BigImagePanel.SetActive(false);
    }
  void Update()
    {
    clickCloseButton();
    if(placeButton == true){
       BigImagePanel.SetActive(false);
    }
       //closeBtn.onClick.AddListener(clickCloseButton);

      
    }
    

 
   
}
