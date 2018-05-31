using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScoreWin : MonoBehaviour {

	public RawImage best;
	public RawImage sc;
	public Text t;
	// Use this for initialization

	void Start () {
		best.gameObject.SetActive (false);
		sc.gameObject.SetActive (false);
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		t.text = "" + PlayerDef.instance.score;
		Debug.Log ("old score "+PlayerDef.instance.oldScore);
		Debug.Log ("score "+PlayerDef.instance.score);

		if(PlayerDef.instance.score > PlayerDef.instance.oldScore){ //best score
			best.gameObject.SetActive(true);
			SaveData.instance.Over ();
			//saveMoney.instance.over();
			//print("best");
		}
		else{ //score
			sc.gameObject.SetActive(true);
			SaveData.instance.Over ();
//			saveMoney.instance.over();
			//print("non");
		}


	}

	
}
