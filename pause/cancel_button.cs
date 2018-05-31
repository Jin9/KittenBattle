using UnityEngine;
using System.Collections;

public class cancel_button : MonoBehaviour { //from pause

	public Canvas p;

	public void click(){

		if (firstManeger.instance.state == 3) {
			GameManager.instance.isPause = false;
			p.gameObject.SetActive (false);
			Time.timeScale = 1.0f;
		}
		else if(firstManeger.instance.state == 4){
			AtkGameManager.instance.isPause = false;
			p.gameObject.SetActive (false);
			Time.timeScale = 1.0f;
		}

		else if(firstManeger.instance.state == 8){
			SpdManager.instance.isPause = false;
			p.gameObject.SetActive (false);
			Time.timeScale = 1.0f;

		}

	}
}
