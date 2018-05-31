using UnityEngine;
using System.Collections;

public class release : MonoBehaviour {

	public void clickok(){
		Debug.Log ("click ok");
		firstManeger.instance.state = 9; //go delete cat in database
		Application.LoadLevel ("loadScreen");
	}
}
