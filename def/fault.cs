using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fault : MonoBehaviour {

	public RawImage raw;
	// Use this for initialization
	void Start () {
		//gameObject.SetActive (false);
		raw.color = new Color(0,0,0,1);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){

		}
	}
}
