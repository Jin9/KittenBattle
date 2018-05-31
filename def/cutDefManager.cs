using UnityEngine;
using System.Collections;

public class cutDefManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
	
	}
}
