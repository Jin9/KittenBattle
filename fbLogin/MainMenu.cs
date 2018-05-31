using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject UIFBIsLogedIn;
	public GameObject UIFBNotIsLogedIn;

	void Awake ()
	{
		//Debug.Log ("fb init");
		FB.Init (SetInit, OnHideUnity);

	}
	
	private void SetInit (){
		
		Debug.Log ("FB init done");
		
		if (FB.IsLoggedIn){
			DealWithFBMenus(true); 
		}
		else {
			DealWithFBMenus(false);
		}
	}
	
	private void OnHideUnity(bool isGameShown){
		if (!isGameShown) {				
			Time.timeScale = 0;		
		} 
		else {
			Time.timeScale = 1;		
		}
	}

	public void FBlogin(){
		
		FB.Login ("email" , AuthCallback);
		
	}

	public void AuthCallback(FBResult result){
		
		if (FB.IsLoggedIn) {
			Debug.Log ("FB login worked! "+FB.UserId);
			firstManeger.instance.FBid = FB.UserId;
			DealWithFBMenus(true);
			
		} 
		else {
			Debug.Log ("FB login fail.");
			//firstManeger.instance.FBid = FB.UserId;
			DealWithFBMenus(false);
			
		}
	}

	public void DealWithFBMenus(bool isLoggedIn){
		if (isLoggedIn) {
			UIFBIsLogedIn.SetActive(true);
			UIFBNotIsLogedIn.SetActive(false);

			firstManeger.instance.state = 1;
			firstManeger.instance.FBid = FB.UserId;
			print(firstManeger.instance.FBid);
			Application.LoadLevel("loadScreen");

		} else {
			UIFBIsLogedIn.SetActive(false);
			UIFBNotIsLogedIn.SetActive(true);

			firstManeger.instance.state = 5;
			//Application.LoadLevel("firstPage");
		}
		
	}
}
