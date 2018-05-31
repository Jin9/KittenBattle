using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AtkGameManager : MonoBehaviour {

	public static AtkGameManager instance;
	float time = 30.0f;
	public bool isPause = false;
	float dist = 5.49f;
	public RawImage t;
	public bool isready = false;
	public AudioClip scratchSound;
	public bool die = false;

	float themo = 0.0f;
	float timeThe = 0.1f;
	public RawImage red1;

	// Use this for initialization
	void Start () {
		instance = this;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Time.timeScale = 0.0f;

		//Debug.Log ("Strat atk");
	}

	public void playSound(){
		GetComponent<AudioSource>().PlayOneShot (scratchSound);
	}

	public void setThemo(){

		if (themo < 0.9f) {
			themo += 0.02f;
			red1.transform.localScale = new Vector3 (0.86f,themo,1.0f);
		}
		else{ //over
			die = true;
			Application.LoadLevel("atkGameWin");
		}

		timeThe = 0.3f;
	}


	// Update is called once per frame
	void Update () {
		//Debug.Log ("isready " + isready);
		if (isPause == false && isready == true) {
			time -= Time.deltaTime;
			//Debug.Log(Mathf.Floor(time));
			if(time > 0){
				dist = dist -0.0032f;
				if(dist > 0){
					t.transform.localScale = new Vector3(dist ,0.23f,1.0f);
				}

				timeThe -= Time.deltaTime;
				if(timeThe < 0.0f ){

						if(themo > 0){
							themo -= 0.02f;
							if(themo < 0){
								red1.transform.localScale = new Vector3 (0.86f,0,1.0f);
							}
							else{
								red1.transform.localScale = new Vector3 (0.86f,themo,1.0f);
							}

						}
					
					timeThe = 0.1f;
				}
				
			}
			else{
				Application.LoadLevel("atkGameWin");
			}
		}
	}

}