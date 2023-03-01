using UnityEngine;
using UnityEngine.Events;


public class Clickhandler: MonoBehaviour
{
    [SerializeField]
	
	UnityEvent clickEvent; 

	void OnMouseUpAsButton(){
		clickEvent?.Invoke();
	}


	/* 
	//Input.touchCount
	public event EventHandler MyEvent;
	void OnMouseUpAsButton(){

	MyEvent?.Invoke(this, EventArgs.Empty);
	}
	*/
}
