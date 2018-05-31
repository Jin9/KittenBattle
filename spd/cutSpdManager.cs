using UnityEngine;
using System.Collections;

public class cutSpdManager : MonoBehaviour {

	public Camera side;
	public Camera front;
	// Use this for initialization
	void Start () {

		side.GetComponent<Camera>().enabled = true;
		front.GetComponent<Camera>().enabled = false;

		Screen.orientation = ScreenOrientation.LandscapeLeft;
		if (firstManeger.instance.count == 0) {
			ChangeTexture.instance.change (firstManeger.instance.texcat1);	
		}
		else if(firstManeger.instance.count == 1){
			ChangeTexture.instance.change (firstManeger.instance.texcat2);
		}
		else if(firstManeger.instance.count == 2){
			ChangeTexture.instance.change (firstManeger.instance.texcat3);
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (walk.instace.setCam == true) {
			side.GetComponent<Camera>().enabled = false;
			front.GetComponent<Camera>().enabled = true;	
		}
	}
}
