using UnityEngine;
using UnityEngine.UI;

public class MediaPlayer : Screen_ 
{
	[SerializeField]
	RawImage mediaImage;
	
   protected override void Start(){
		  base.Start();
		  CloseScreen(); 
   }
   public void OpenScreen(Texture imageTex){
		  mediaImage.texture = imageTex;
		  SetScreen(true); 
   }
   public void CloseScreen(){
	
		  SetScreen(false); 
   }
}
