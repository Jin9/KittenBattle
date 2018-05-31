using UnityEngine;
using System.Collections;

public class goDef : MonoBehaviour {
	

	public void click(){
		Debug.Log ("clickOk");
		
		if (firstManeger.instance.count == 0) {
			firstManeger.instance.enC1 -= 5;
		} else if (firstManeger.instance.count == 1) {
			firstManeger.instance.enC2 -= 5;	
		} else if (firstManeger.instance.count == 2) {
			firstManeger.instance.enC3 -= 5;	
		}
		
		
		easyEn.instance.callFunc ();
		firstManeger.instance.state = 3;
		
		Debug.Log ("state is "+firstManeger.instance.state);
		Application.LoadLevel ("loadScreen");
	}
}
