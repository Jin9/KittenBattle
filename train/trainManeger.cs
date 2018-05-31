using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class trainManeger : MonoBehaviour {

	public static trainManeger instance;
	public GameObject atk;
	public GameObject def;
	public GameObject spd;

	public Canvas setting;
	public Canvas warning;
	public Canvas atks;
	public Canvas defS;
	public Canvas spdS;
	public Canvas expDe;

	public bool ispopup = false;

	public Text name;
	public Text degree;
	public Text money;

	// Use this for initialization
	void Start () {
		instance = this;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		firstManeger.instance.state = 2;
		Debug.Log ("(train)state is "+ firstManeger.instance.state);
		Debug.Log ("(train)cat is "+ firstManeger.instance.count);

		name.text = firstManeger.instance.name;
		degree.text = firstManeger.instance.level;
		money.text = ""+firstManeger.instance.money+"  .M";

		atks.gameObject.SetActive (false);
		defS.gameObject.SetActive (false);
		spdS.gameObject.SetActive (false);
		warning.gameObject.SetActive (false);
		setting.gameObject.SetActive (false);
		expDe.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
