using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpdManager : MonoBehaviour {

	public static SpdManager instance;
	public float time = 30.0f;
	float d = 2.0f;
	public GameObject cat;
	public Canvas pic;
	public Canvas score;
	public Canvas over;

	public bool isready = false;
	public bool isPause = false;
	public bool isdie = false;
	public bool iswin = false;

	float dist = 1.0f;
	public RawImage t;

	public int s;
	public int oldScore;

	// Use this for initialization
	void Start () {
	
		instance = this;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Time.timeScale = 1.0f;
		s = storageData.instance.oldScore;

		Debug.Log ("old score is " +s);
		pic.gameObject.SetActive (false);
		score.gameObject.SetActive (false);
		over.gameObject.SetActive (false);

		Screen.orientation = ScreenOrientation.LandscapeLeft;
		if (firstManeger.instance.count == 0) {
			ChangeTexture.instance.change (firstManeger.instance.texcat1);	
		}
		else if(firstManeger.instance.count == 1){
			ChangeTexture.instance.change (firstManeger.instance.texcat2);
		}
		else if(firstManeger.instance.count == 2){
			ChangeTexture.instance.change (firstManeger.instance.texcat3);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (firstManeger.instance.count == 0) {
			ChangeTexture.instance.change (firstManeger.instance.texcat1);	
		}
		else if(firstManeger.instance.count == 1){
			ChangeTexture.instance.change (firstManeger.instance.texcat2);
		}
		else if(firstManeger.instance.count == 2){
			ChangeTexture.instance.change (firstManeger.instance.texcat3);
		}

		if (isPause == false && isready == true && iswin == false) {
			time -= Time.deltaTime;
			//Debug.Log(Mathf.Floor(time));
			if(time > 0){
				dist = dist -0.00055f;
				if(dist > 0)
					t.transform.localScale = new Vector3(dist ,1.0f,1.0f);
				
			}
			//Debug.Log(time);
			else if (time < 0) {
				//Application.LoadLevel("defGameWin");	
				Time.timeScale = 0.0f;
				over.gameObject.SetActive(true);
				Debug.Log("Time out");
			}	

			if(isdie == true){

				d -= Time.deltaTime;

				if(d < 0){
					isdie = false;
				}
			}
		}
	}
}
