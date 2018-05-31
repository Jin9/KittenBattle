using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	float time = 30.0f;
	public bool isPause = false;
	public static GameManager instance;
	public AudioClip clip;
	public AudioClip missSound;
	float dist = 5.49f;
	public RawImage t;
	public bool isready = false;

	// Use this for initialization
	void Start () {
	
		instance = this;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Time.timeScale = 1.0f;
	}

	public void playSound(){
		//Debug.Log ("yes");
		GetComponent<AudioSource>().PlayOneShot (clip);
	}

	public void PlayMiss(){
		GetComponent<AudioSource>().PlayOneShot (missSound);
	}
	
	// Update is called once per frame
	void Update () {

		if (isPause == false && isready == true) {
			time -= Time.deltaTime;
			//Debug.Log(Mathf.Floor(time));
			if(time > 0){
				dist = dist -0.0032f;
				if(dist > 0)
					t.transform.localScale = new Vector3(dist ,0.23f,1.0f);
				
			}
			//Debug.Log(time);
			else if (time < 0) {
				Application.LoadLevel("defGameWin");		
			}	
		}
			

	}


}
