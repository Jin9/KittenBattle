using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Toselect : MonoBehaviour {

	public Text t;
	public void click(){

		//Debug.Log (t.text);
		newPlayerManager.instance.name = t.text;
		Debug.Log (newPlayerManager.instance.name);

		Application.LoadLevel ("box");
	}
}
