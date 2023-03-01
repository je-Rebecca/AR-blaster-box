using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
	private bool toggle = false;
    // Start is called before the first frame update
    public GameObject BtnClick;
public GameObject welcomePanel;
public Button dismissButton;
	void awake(){
dismissButton.onClick.AddListener(Dismiss);

}       void start(){

       }

       void update(){

       }
       public void click(){
       toggle =!toggle; 
        /*toggle=  toggle? toggle=true: toggle=false;*/
         BtnClick.SetActive(toggle);
	
       }
public void Dismiss(){
    welcomePanel.SetActive(false);
    }

    
}
