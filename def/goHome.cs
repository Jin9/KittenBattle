using UnityEngine;
using System.Collections;

public class goHome : MonoBehaviour {

	public void click(){

		firstManeger.instance.state = 1;
		Application.LoadLevel ("loadScreen");
	}
}
