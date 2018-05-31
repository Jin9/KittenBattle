using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class rankManager : MonoBehaviour {

	public static rankManager instance;

	public bool ispopUp = false;

	public Text name;
	public Text degree;
	public Text money;


	public Canvas expDe;
	public Canvas sub;
	public Canvas setting;

	public GameObject scorey1;
	public GameObject scorey2;
	public GameObject atk1;
	public GameObject def1;
	public GameObject spd1;
	public GameObject atk2;
	public GameObject def2;
	public GameObject spd2;

	public Text atk;
	public Text def;
	public Text spd;
	public GameObject myScore;

	public GameObject rank;
	public Text name1;
	public Text name2;
	public Text name3;
	public Text name4;
	public Text name5;

	public Text lv1;
	public Text lv2;
	public Text lv3;
	public Text lv4;
	public Text lv5;

	public Text score1;
	public Text score2;
	public Text score3;
	public Text score4;
	public Text score5;


	// Use this for initialization
	void Start () {
	
		instance = this;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		
		Debug.Log ("(rank)state is "+ firstManeger.instance.state);
		
		name.text = firstManeger.instance.name;
		degree.text = firstManeger.instance.level;
		money.text = ""+firstManeger.instance.money+"  .M";

		expDe.gameObject.SetActive (false);
		sub.gameObject.SetActive (false);
		setting.gameObject.SetActive (false);
		scorey1.SetActive (false);
		atk2.SetActive (false);
		def2.SetActive (false);
		spd2.SetActive (false);
		scorey2.SetActive (true);
		atk1.SetActive (true);
		def1.SetActive (true);
		spd1.SetActive (true);

		rank.SetActive (false);
		myScore.SetActive (true);
		atk.text = "" + storageData.instance.myAtk;
		def.text = "" + storageData.instance.myDef;
		spd.text = "" + storageData.instance.mySpd;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
