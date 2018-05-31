using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowwinAtk : MonoBehaviour {

	public static ShowwinAtk instance;
	public RawImage best;
	public RawImage sc;
	public Text t;
	// Use this for initialization
	
	void Start () {
		instance = this;
	}

	public void callWin(){
		best.gameObject.SetActive (false);
		sc.gameObject.SetActive (false);
		
		t.text = "" + PlayerAtk.instance.score;
		Debug.Log ("old score "+PlayerAtk.instance.oldScore);
		Debug.Log ("score "+PlayerAtk.instance.score);
		
		if(PlayerAtk.instance.score > PlayerAtk.instance.oldScore){ //best score
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
