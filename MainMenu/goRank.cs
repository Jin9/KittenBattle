using UnityEngine;
using System.Collections;

public class goRank : MonoBehaviour {

	public void click(){
		
		firstManeger.instance.state = 12;
		Application.LoadLevel ("loadScreen");
	}
}
