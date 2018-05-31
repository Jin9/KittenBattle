using UnityEngine;
using System.Collections;

public class NPChangeTex : MonoBehaviour {

	public static NPChangeTex instance;
	// Use this for initialization
	void Start () {
	
		instance = this;
	}

	public void change(string pic){
		GetComponent<Renderer>().material.mainTexture = Resources.Load(pic,typeof(Texture))as Texture;
	}
}
