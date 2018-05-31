using UnityEngine;
using System.Collections;

public class goShop : MonoBehaviour {

	public void click(){

		firstManeger.instance.state = 10;
		Application.LoadLevel ("shop");
	}
}
