using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setFeet : MonoBehaviour {

	public RawImage feetl;
	public RawImage feetc;
	public RawImage feetr;
	
	// Use this for initialization
	void Start () {
		feetl.gameObject.SetActive (false);
		feetc.gameObject.SetActive (false);
		feetr.gameObject.SetActive (false);

	}
	
}
