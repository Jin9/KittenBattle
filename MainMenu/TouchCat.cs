using UnityEngine;
using System.Collections;

public class TouchCat : MonoBehaviour {

	//public Animator anim;

	void Start(){
	//	anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	public void click(){
		if (MainManeger.instance.ispopUp == false) {

			Animate.instance.click = 1;	
		}


	}
}
