using UnityEngine;
using System.Collections;

public class showCatManager : MonoBehaviour {

	public static showCatManager instance;
	public Canvas fill;
	public AudioClip c;
	// Use this for initialization
	void Start () {
	
		instance = this;
		fill.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (firstManeger.instance.state == 11) {
			ChangeTexture.instance.change (firstManeger.instance.catTexBuy);	
		}
		else{
			ChangeTexture.instance.change (newPlayerManager.instance.texCat);
		}

	}

	public void  PlaySound(){
		GetComponent<AudioSource>().PlayOneShot (c);
	}
}
