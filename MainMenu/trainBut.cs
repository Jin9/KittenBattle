using UnityEngine;
using System.Collections;

public class trainBut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void click(){
		firstManeger.instance.state = 2;
		//Debug.Log ("(train)state is "+ firstManeger.instance.state);
		//Debug.Log ("(train)cat is "+ firstManeger.instance.count);

		Application.LoadLevel ("train");
	}
}
