using UnityEngine;
using System.Collections;

public class LoadManager : MonoBehaviour {

	public static LoadManager instance;
	float t = 10.0f;
	// Use this for initialization
	void Start () {
		instance = this;
		//connect = true;
		//Debug.Log ("connect is "+ connect);
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		if(firstManeger.instance.state == 1){ //main
			//lodeCat.instance.callLoadCat();
			Debug.Log ("ooooJinoooo state 1");
			loadPlayerData.instance.callFunc();
		}
		else if (firstManeger.instance.state == 3) {//def
			OldScore.instance.callFunc();
		}
		else if(firstManeger.instance.state == 4){//atk
			oldScoreAtk.instance.callFunc();
		}
		else if(firstManeger.instance.state == 5){ //login
		//	Application.LoadLevel ("FBScene2");
		}
		else if(firstManeger.instance.state == 7){ // save new player
			Debug.Log("state 7");
			saveNewPlayer.instance.callFunc();
		}
		else if(firstManeger.instance.state == 8){ //spd
			//Application.LoadLevel("spdGame");
			oldScoreSpd.instance.callFunc();
		}
		else if(firstManeger.instance.state == 9){ //delete cat
			deleteCat.instance.callFunc();
		}
		else if(firstManeger.instance.state == 10){ // shop
			loadPlayerData.instance.callFunc();
		}
		else if(firstManeger.instance.state == 11){ // add new cat
			saveNewPlayer.instance.callFunc();
		}
		else if(firstManeger.instance.state == 12){ // rank
			getRanking.instance.callFunc();
		}
		else if(firstManeger.instance.state == 13){ // save exp battle
			saveExpPlayer.instance.callFunc();

		}
	
	}
	
	// Update is called once per frame
	void Update () {
		t -= Time.deltaTime;
		if (t < 0) {
			//Time.timeScale = 0.0f;
			setPopup.instance.callShow();
			t = 10.0f;
		}
		//Debug.Log ("connect is "+ connect);
		if(firstManeger.instance.connect == false){
			if(firstManeger.instance.state == 1){//main
				loadPlayerData.instance.callFunc();
			}
			else if (firstManeger.instance.state == 3) {//def
				OldScore.instance.callFunc();
			}
			else if(firstManeger.instance.state == 4){//atk
				//print("in loading");
				oldScoreAtk.instance.callFunc();
			}
			else if(firstManeger.instance.state == 5){ //login
				Application.LoadLevel ("FBScene2");
			}
			else if(firstManeger.instance.state == 7){ // save new player
				Debug.Log ("in false state 7");
				//saveNewPlayer.instance.callFunc();
			}
			else if(firstManeger.instance.state == 8){ //spd
				//Application.LoadLevel("spdGame");
				oldScoreSpd.instance.callFunc();
			}
			else if(firstManeger.instance.state == 9){ //delete cat
				deleteCat.instance.callFunc();
			}
			else if(firstManeger.instance.state == 11){ // add new cat
				saveNewPlayer.instance.callFunc();
			}
			else if(firstManeger.instance.state == 10){ // shop
				loadPlayerData.instance.callFunc();
			}
			else if(firstManeger.instance.state == 12){ // rank
				getRanking.instance.callFunc();
			}
			else if(firstManeger.instance.state == 13){ // save exp battle
				saveExpPlayer.instance.callFunc();
			}
		
		}


	}
}
