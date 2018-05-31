using UnityEngine;
using System.Collections;

public class scissor : MonoBehaviour {


	public void click(){
		
		GPGholder.Instance.myChoose = 'S';
		friendManager.instance.battle.gameObject.SetActive (false);
		friendManager.instance.imWait.gameObject.SetActive (true);
	}
}
