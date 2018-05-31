using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class firstManeger : MonoBehaviour {

	public static firstManeger instance;
	public int state = 0;

	public bool connect = false;

	public int battle;
	public string playerId;
	public string FBid;

	public int count = 0;
	public int limit = 0;

	public string catTexBuy;
	public string catNameBuy;
	
	public string texcat1;
	public string texcat2;
	public string texcat3;
	
	public string catid1;
	public string catid2;
	public string catid3;

	//Player Data
	public string name;
	public string level;
	public int money;
	public int expP;
	public int expFullP;


	//cat Data

	public string nameC1;
	public int levelC1;
	public int enC1;
	public int expC1;
	public string hpC1;
	public string atkC1;
	public string defC1;
	public string spdC1;
	public int expFullC1;
	public int enFullC1;
	public string foodC1;
	public string ringC1;

	public string nameC2;
	public int levelC2;
	public int enC2;
	public int expC2;
	public string hpC2;
	public string atkC2;
	public string defC2;
	public string spdC2;
	public int expFullC2;
	public int enFullC2;
	public string foodC2;
	public string ringC2;

	public string nameC3;
	public int levelC3;
	public int enC3;
	public int expC3;
	public string hpC3;
	public string atkC3;
	public string defC3;
	public string spdC3;
	public int expFullC3;
	public int enFullC3;
	public string foodC3;
	public string ringC3;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		instance = this;
		PlayGamesPlatform.Activate ();
//		Debug.Log ("time is " + Time.realtimeSinceStartup);

		Debug.Log ("(first)state is " + state);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setTexCat1(string pic){
		texcat1 = pic;
		//Debug.Log (texcat1);
	}
	public void setTexCat2(string pic){
		texcat2 = pic;
	}
	public void setTexCat3(string pic){
		texcat3 = pic;
	}
}
