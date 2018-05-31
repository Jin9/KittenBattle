using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class toFill : MonoBehaviour {

	public Canvas fill;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void click(){
		fill.gameObject.SetActive (true);
	}
}
