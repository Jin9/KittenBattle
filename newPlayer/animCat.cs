using UnityEngine;
using System.Collections;

public class animCat : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
		anim.SetTrigger ("cry");
		showCatManager.instance.PlaySound ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
