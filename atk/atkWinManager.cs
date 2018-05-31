using UnityEngine;
using System.Collections;

public class atkWinManager : MonoBehaviour {

	public Canvas win;
	public Canvas over;

	void Awake(){

		win.gameObject.SetActive (false);
		over.gameObject.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		if (PlayerAtk.instance.score >= 300 && AtkGameManager.instance.die == false) { //win
			ShowwinAtk.instance.callWin();
			win.gameObject.SetActive (true);
		}
		else{//over
			over.gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
