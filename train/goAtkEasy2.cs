using UnityEngine;
using System.Collections;

public class goAtkEasy2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void clickOk(){

		Debug.Log ("clickOk");

		if (firstManeger.instance.count == 0) {
			firstManeger.instance.enC1 -= 5;
		} else if (firstManeger.instance.count == 1) {
			firstManeger.instance.enC2 -= 5;	
		} else if (firstManeger.instance.count == 2) {
			firstManeger.instance.enC3 -= 5;	
		}


		easyEn.instance.callFunc ();
		firstManeger.instance.state = 4;
		
		Debug.Log ("state is "+firstManeger.instance.state);
		Application.LoadLevel ("loadScreen");
	}
}
