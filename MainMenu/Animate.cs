using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {

	public static Animate instance;
	public Animator anim;

	public int click = 0;
	public float t = 5.0f;
	void Start(){
		instance = this;
		anim = GetComponent<Animator> ();
	}

	void Update(){

		if (anim) {

			t -= Time.deltaTime;
			if(t < 0){
				if(click == 0){
					anim.SetTrigger("isHead");
					t = 10;
				}

			}
			if(click == 1){
				anim.SetTrigger("isTouch");
				MainManeger.instance.PlaySound();
				click = 0;
				t = 10;
			}
		}

	}
	

}
