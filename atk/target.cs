using UnityEngine;
using System.Collections;

public class target : MonoBehaviour {

	public Canvas tar;
	public int c = 0;
	public static target instance;
	// Use this for initialization
	void Start () {
	
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void click(){
		tar.gameObject.SetActive (false);
		c = 1;
		Time.timeScale = 1.0f;
	}
}
