using UnityEngine;
using System.Collections;

public class soundCat : MonoBehaviour {

	public AudioClip c;
	public static soundCat instance;

	void Start(){
		instance = this;
	}

	public void playSound(){
		GetComponent<AudioSource>().PlayOneShot (c);
	}
}
