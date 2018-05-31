using UnityEngine;
using System.Collections;

public class goFriend : MonoBehaviour {

	public void click(){
		
		firstManeger.instance.state = 13;
		Application.LoadLevel ("friend");
	}
}
