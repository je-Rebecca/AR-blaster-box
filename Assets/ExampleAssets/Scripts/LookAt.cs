using UnityEngine;

public class LookAt : MonoBehaviour
{
	Transform mainCam; 
 void Start()
    {
        mainCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCam); 
    }
}
