using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showScoreAtk : MonoBehaviour {

	public Canvas pic;
	public Canvas score;
	
	public void Click(){
		pic.gameObject.SetActive (false);
		score.gameObject.SetActive (true);
		
		//Debug.Log ("click");
	}
}
