using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	void Start(){

	}
	void OnTouchDown(){
		if (transform.position.z >= (-14.5) && transform.position.z <= (-10.5)) {

			GameManager.instance.playSound();
			setcombo.instance.showCombo();

			Destroy (gameObject);

			PlayerDef.instance.combo++;
			PlayerDef.instance.scoreUpdate();

		}
	
	}
}
