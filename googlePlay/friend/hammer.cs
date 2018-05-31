using UnityEngine;
using System.Collections;

public class hammer : MonoBehaviour {

	public void click(){
		
		GPGholder.Instance.myChoose = 'H';
		friendManager.instance.battle.gameObject.SetActive (false);
		friendManager.instance.imWait.gameObject.SetActive (true);
		
	}
}
