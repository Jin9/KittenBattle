using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAtk : MonoBehaviour {

	public static PlayerAtk instance;
	public int score = 0;
	public Text t;

	public int oldScore = 0;
	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start(){
		oldScore = storageData.instance.oldScore;
	}
	// Update is called once per frame
	void Update () {
		t.text = "Score: " + score.ToString();
	}

	public void scoreUpdate(int s){

		score += s;
	}
}
