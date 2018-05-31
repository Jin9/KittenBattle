using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setcombo : MonoBehaviour {

	public static setcombo instance;
	public Canvas c;
	public RawImage m;
	float t = 0.0f;
	// Use this for initialization
	void Start () {
		instance = this;
		c.gameObject.SetActive (false);
		m.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		t -= Time.deltaTime;
		if(t < 0){
			c.gameObject.SetActive(false);
			m.gameObject.SetActive(false);
		}
	}

	public void showCombo(){
		c.gameObject.SetActive (true);
		t = 0.2f;
	}

	public void showMiss(){
		m.gameObject.SetActive (true);
		t = 0.2f;
	}
}
