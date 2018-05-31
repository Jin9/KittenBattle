using UnityEngine;
using System.Collections;

public class paper : MonoBehaviour {


	public void click(){
		
		GPGholder.Instance.myChoose = 'P';
		friendManager.instance.battle.gameObject.SetActive (false);
		friendManager.instance.imWait.gameObject.SetActive (true);
	}
}
