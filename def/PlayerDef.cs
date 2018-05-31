using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDef : MonoBehaviour {

	public static PlayerDef instance;
	public int score = 0;
	public int miss = 0;
	public Text s;

	public int combo = 0;
	public Text com;
	public bool isDone = false;
	float t = 0.0f;

	public int oldScore ;

	public RawImage one;
	public RawImage onePointFive;
	public RawImage two;

	void Awake(){

		instance = this;

	}

	void Start(){
		oldScore = storageData.instance.oldScore;
		one.gameObject.SetActive (false);
		onePointFive.gameObject.SetActive (false);
		two.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		s.text = "Score: " + score.ToString();
		com.text = ""+combo;

		if(isDone = true){
			t -= Time.deltaTime;
			if(t < 0){
				isDone = false;
			}
		}

		if (combo >= 16) {
			onePointFive.gameObject.SetActive(false);
			two.gameObject.SetActive(true);
		}
		else if(combo >= 8){
			one.gameObject.SetActive(false);
			onePointFive.gameObject.SetActive(true);
		}
		else if (combo >= 1) {

			one.gameObject.SetActive(true);	
		}
		else if (combo == 0){
			two.gameObject.SetActive(false);
			onePointFive.gameObject.SetActive(false);
		}
	}


	public void scoreUpdate(){
		isDone = true;
		//Debug.Log (score);
		t = 0.2f;

		if (combo >= 16) {
			score = score +20;	

		}
		else if (combo >= 8) {
			score = score +15;	
		}
		else{
			score = score +10;
		}

	}


}
