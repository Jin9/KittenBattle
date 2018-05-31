using UnityEngine;
using System.Collections;

public class defButton : MonoBehaviour {
	public void clickDef(){
		
		rankManager.instance.def2.SetActive (true);
		rankManager.instance.def1.SetActive (false);
		rankManager.instance.atk2.SetActive (false);
		rankManager.instance.atk1.SetActive (true);
		rankManager.instance.spd2.SetActive (false);
		rankManager.instance.spd1.SetActive (true);

		rankManager.instance.scorey1.SetActive (true);
		rankManager.instance.scorey2.SetActive (false);
		
		rankManager.instance.rank.SetActive (true);
		rankManager.instance.myScore.SetActive (false);

		rankManager.instance.score1.text = "" + storageData.instance.def1;
		rankManager.instance.name1.text = "" + storageData.instance.Dname1;
		rankManager.instance.lv1.text = "" + storageData.instance.Dlv1;

		rankManager.instance.score2.text = "" + storageData.instance.def2;
		rankManager.instance.name2.text = "" + storageData.instance.Dname2;
		rankManager.instance.lv2.text = "" + storageData.instance.Dlv2;

		rankManager.instance.score3.text = "" + storageData.instance.def3;
		rankManager.instance.name3.text = "" + storageData.instance.Dname3;
		rankManager.instance.lv3.text = "" + storageData.instance.Dlv3;

		rankManager.instance.score4.text = "" + storageData.instance.def4;
		rankManager.instance.name4.text = "" + storageData.instance.Dname4;
		rankManager.instance.lv4.text = "" + storageData.instance.Dlv4;

		rankManager.instance.score5.text = "" + storageData.instance.def5;
		rankManager.instance.name5.text = "" + storageData.instance.Dname5;
		rankManager.instance.lv5.text = "" + storageData.instance.Dlv5;
	}
}
