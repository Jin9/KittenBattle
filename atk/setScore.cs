using UnityEngine;
using System.Collections;

public class setScore : MonoBehaviour {

	public static setScore instance;
	public int count = 0;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTouchStay(){


		count = 1;
		//print (count);
		/*
		count++;
		//Debug.Log (count);
		if (count < 10) {
			if(AtkGameManager.instance.isPause == false){
				//count = 1;
				PlayerAtk.instance.scoreUpdate (1);
			}
		}
		else{
			//Debug.Log("kk");
		}
*/
	}

}
