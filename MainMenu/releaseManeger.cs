using UnityEngine;
using System.Collections;

public class releaseManeger : MonoBehaviour {

	public Canvas notrelease;
	public Canvas release;

	void Start(){

	}
	public void click(){

		if (firstManeger.instance.limit == 1) {
			MainManeger.instance.ispopUp = true;
			notrelease.gameObject.SetActive(true);
		}
		else{
			MainManeger.instance.ispopUp = true;
			release.gameObject.SetActive(true);
		}
	}
}
