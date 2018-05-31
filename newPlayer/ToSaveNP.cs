using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToSaveNP : MonoBehaviour {

	public Text te;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void click(){
		if(firstManeger.instance.state == 6){
			newPlayerManager.instance.catName = te.text;
			Debug.Log (newPlayerManager.instance.catName);
			firstManeger.instance.state = 7;
			Application.LoadLevel ("loadScreen");
		}
		else if(firstManeger.instance.state == 11){
			firstManeger.instance.catNameBuy = te.text;
			Application.LoadLevel("loadScreen");
		}

	}
}
