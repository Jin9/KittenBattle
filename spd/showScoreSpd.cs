using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showScoreSpd : MonoBehaviour {

	public Canvas pic;
	public Canvas score;

	public RawImage best;
	public RawImage sc;
	public Text t;

	public void click(){
		pic.gameObject.SetActive (false);
		score.gameObject.SetActive (true);

		best.gameObject.SetActive (false);
		sc.gameObject.SetActive (false);

		t.text = "" + SpdManager.instance.s;

		if(SpdManager.instance.s > SpdManager.instance.oldScore){ //best score
			best.gameObject.SetActive(true);
			SaveData.instance.Over ();
		}
		else{ //score
			sc.gameObject.SetActive(true);
			SaveData.instance.Over ();
		
		}
	}
}
