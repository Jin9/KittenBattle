using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var s = "10";
		string a = s.Substring (1,s.Length-2);
		Debug.Log (s);
		int x;
		x = int.Parse (s);
		Debug.Log (x);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
