using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public Canvas p;
	//public Canvas popUp;

	void Start(){

		p.gameObject.SetActive (false);
	}

	public void Click(){

		if (firstManeger.instance.state == 3) {
			if (GameManager.instance.isPause == false) {
				GameManager.instance.isPause = true;
				p.gameObject.SetActive (true);
				Time.timeScale = 0.0f;
			}
		}
		else if(firstManeger.instance.state == 4){
			if (AtkGameManager.instance.isPause == false) {
				AtkGameManager.instance.isPause = true;
				p.gameObject.SetActive (true);
				Time.timeScale = 0.0f;

			}
		}
		else if(firstManeger.instance.state == 8){
			if (SpdManager.instance.isPause == false) {
				SpdManager.instance.isPause = true;
				p.gameObject.SetActive (true);
				Time.timeScale = 0.0f;
				
			}
		}



	}
}
