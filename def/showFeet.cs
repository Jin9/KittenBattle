using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showFeet : MonoBehaviour {

	public static showFeet instance;
	public RawImage feet;
	float t = 0.2f;
	int i = 0;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (feet.IsActive () == true) {
			t -= Time.deltaTime;
			if(t < 0){
				feet.gameObject.SetActive(false);
				t = 0.2f;
			}
		}
	}

	public void Click(){
		if (GameManager.instance.isready == true && GameManager.instance.isPause == false) {
			feet.gameObject.SetActive (true);
			if (PlayerDef.instance.isDone == false) {
				PlayerDef.instance.combo = 0;
				setcombo.instance.showMiss();
				//print("false");
			}
		}


	}
}
