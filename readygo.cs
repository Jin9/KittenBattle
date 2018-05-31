using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class readygo : MonoBehaviour {
	public static readygo instance;
	public RawImage ready;
	public RawImage go;
	public float t = 3.0f;

	void Awake(){
		instance = this;
		go.color = new Color (1,1,1,0);
		ready.color = new Color (1,1,1,0);
	}
	// Use this for initialization
	void Start () {
		if (firstManeger.instance.state == 3) {
			ready.color = new Color (1,1,1,1);
		}
		if(firstManeger.instance.state == 8){
			ready.color = new Color (1,1,1,1);
		}
		//Time.timeScale = 1.0f;

		//Debug.Log("start ready");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("update");
		if (firstManeger.instance.state == 3) {
			t -= Time.deltaTime;
			if (t < 0.5 ) {
				go.color = new Color(1,1,1,0);
				GameManager.instance.isready = true;
			}
			else if (t < 1.5) {
				ready.color = new Color(1,1,1,0);
				go.color = new Color(1,1,1,1);
			}
		}
		else if(firstManeger.instance.state == 4){
			if(target.instance.c == 1){
				ready.color = new Color (1,1,1,1);
			}
			t -= Time.deltaTime;
			//Debug.Log (Time.deltaTime);
			//Debug.Log("update ready" + t);
			
			if (t < 0.5 ) {
				go.color = new Color(1,1,1,0);
				target.instance.c = 0;
				ready.color = new Color (1,1,1,0);
				AtkGameManager.instance.isready = true;
			}
			else if (t < 1.5) {
				ready.color = new Color(1,1,1,0);
				go.color = new Color(1,1,1,1);
			}

		}

		else if(firstManeger.instance.state == 8){
			t -= Time.deltaTime;
			if (t < 0.5 ) {
				go.color = new Color(1,1,1,0);
				SpdManager.instance.isready = true;
			}
			else if (t < 1.5) {
				ready.color = new Color(1,1,1,0);
				go.color = new Color(1,1,1,1);
			}

		}

	}


}
