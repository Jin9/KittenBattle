using UnityEngine;
using System.Collections;

public class newPlayerManager : MonoBehaviour {

	public static newPlayerManager instance;

	public string name;
	public string texCat;
	public string catName;

	// Use this for initialization
	void Start () {
	
		instance = this;
	}
	

}
