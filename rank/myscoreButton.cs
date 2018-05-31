using UnityEngine;
using System.Collections;

public class myscoreButton : MonoBehaviour {

	public void clickMyScore(){
		
		rankManager.instance.def2.SetActive (false);
		rankManager.instance.def1.SetActive (true);
		rankManager.instance.atk2.SetActive (false);
		rankManager.instance.atk1.SetActive (true);
		rankManager.instance.spd2.SetActive (false);
		rankManager.instance.spd1.SetActive (true);
		
		rankManager.instance.scorey1.SetActive (false);
		rankManager.instance.scorey2.SetActive (true);
		
		rankManager.instance.rank.SetActive (false);
		rankManager.instance.myScore.SetActive (true);
	}
}
