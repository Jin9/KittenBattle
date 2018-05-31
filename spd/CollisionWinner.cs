using UnityEngine;
using System.Collections;

public class CollisionWinner : MonoBehaviour {

	public Canvas pic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("win");
		SpdManager.instance.iswin = true;
		Debug.Log ("time is " + SpdManager.instance.time);
		SpdManager.instance.s = Mathf.FloorToInt(SpdManager.instance.time) * 30;

		Debug.Log (SpdManager.instance.s);
		pic.gameObject.SetActive (true);

	}
}
