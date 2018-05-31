using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setTouch : MonoBehaviour {

	public RawImage touchPic;
	float t = 1.0f;
	// Use this for initialization
	void Start () {
		touchPic.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		t -= Time.deltaTime;

		if( t < 0.0f){
			touchPic.gameObject.SetActive (false);
			t = 1.0f;
		}
		else if (t < 0.5f) {
			touchPic.gameObject.SetActive (true);	
		}


	}
}
