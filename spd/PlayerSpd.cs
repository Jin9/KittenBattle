using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSpd : MonoBehaviour {

	public float speed = 10.0F;
	public float turn = 60.0F;

	float t = 2.0f;

	bool stop = false;
	void start () {

	}

	void Update() {

		Vector3 dir = Vector3.zero; 
		dir.x = Input.acceleration.x;
		//dir.z = -1.0f*Input.acceleration.z;

		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		float horizontal = dir.x * turn * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		if(SpdManager.instance.iswin == true){
			t -= Time.deltaTime;
			if(t < 0){
				stop = true;
			}

		}
		//float vertical = dir.z * speed * Time.deltaTime;
		if(SpdManager.instance.isready == true && SpdManager.instance.isdie == false && stop == false){
			transform.Translate(0, 0, (-Input.acceleration.z)* speed * Time.deltaTime);
		}

	}

}
