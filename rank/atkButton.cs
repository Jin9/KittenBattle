using UnityEngine;
using System.Collections;

public class atkButton : MonoBehaviour {

	public void clickAtk(){

		rankManager.instance.atk2.SetActive (true);
		rankManager.instance.atk1.SetActive (false);
		rankManager.instance.def2.SetActive (false);
		rankManager.instance.def1.SetActive (true);
		rankManager.instance.spd2.SetActive (false);
		rankManager.instance.spd1.SetActive (true);

		rankManager.instance.scorey1.SetActive (true);
		rankManager.instance.scorey2.SetActive (false);

		rankManager.instance.rank.SetActive (true);
		rankManager.instance.myScore.SetActive (false);

		rankManager.instance.score1.text = "" + storageData.instance.atk1;
		rankManager.instance.name1.text = "" + storageData.instance.Aname1;
		rankManager.instance.lv1.text = "" + storageData.instance.Alv1;

		rankManager.instance.score2.text = "" + storageData.instance.atk2;
		rankManager.instance.name2.text = "" + storageData.instance.Aname2;
		rankManager.instance.lv2.text = "" + storageData.instance.Alv2;

		rankManager.instance.score3.text = "" + storageData.instance.atk3;
		rankManager.instance.name3.text = "" + storageData.instance.Aname3;
		rankManager.instance.lv3.text = "" + storageData.instance.Alv3;

		rankManager.instance.score4.text = "" + storageData.instance.atk4;
		rankManager.instance.name4.text = "" + storageData.instance.Aname4;
		rankManager.instance.lv4.text = "" + storageData.instance.Alv4;

		rankManager.instance.score5.text = "" + storageData.instance.atk5;
		rankManager.instance.name5.text = "" + storageData.instance.Aname5;
		rankManager.instance.lv5.text = "" + storageData.instance.Alv5;
	}
}
