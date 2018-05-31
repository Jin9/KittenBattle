using UnityEngine;
using System.Collections;

public class die : MonoBehaviour {

	public GameObject cat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("die");
		SpdManager.instance.isdie = true;
		cat.transform.localPosition = new Vector3 (-4.3f,10.61f,-62.37f);
		cat.transform.rotation = Quaternion.identity;
	}
}
