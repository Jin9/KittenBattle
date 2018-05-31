using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setPopup : MonoBehaviour {

	public Canvas popUp;
	public bool isPopup = false;
	public static setPopup instance;

	// Use this for initialization
	void Start () {
		instance = this;
		popUp.gameObject.SetActive (false);
	}
	
	public void callShow(){
		popUp.gameObject.SetActive (true);
		isPopup = true;
		Time.timeScale = 0.0f;
	}

	public void callHide(){
		popUp.gameObject.SetActive (false);
		isPopup = false;
		Time.timeScale = 1.0f;
	}
}
