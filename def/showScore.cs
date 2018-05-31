using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showScore : MonoBehaviour {

	public Canvas pic;
	public Canvas score;

	public void Click(){
		pic.gameObject.SetActive (false);
		score.gameObject.SetActive (true);

		//Debug.Log ("click");
	}
}
