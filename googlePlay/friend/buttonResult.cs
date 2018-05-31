using UnityEngine;
using System.Collections;

public class buttonResult : MonoBehaviour {

	public void click(){

		friendManager.instance.show.SetActive (false);
			Debug.Log ("ooooJinoooo click "+GPGholder.Instance.rState);
			GPGholder.Instance.animState();

	}
}
