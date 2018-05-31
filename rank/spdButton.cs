using UnityEngine;
using System.Collections;

public class spdButton : MonoBehaviour {

	public void clickSpd(){
		
		rankManager.instance.spd2.SetActive (true);
		rankManager.instance.spd1.SetActive (false);
		rankManager.instance.atk2.SetActive (false);
		rankManager.instance.atk1.SetActive (true);
		rankManager.instance.def2.SetActive (false);
		rankManager.instance.def1.SetActive (true);
		
		rankManager.instance.scorey1.SetActive (true);
		rankManager.instance.scorey2.SetActive (false);
		
		rankManager.instance.rank.SetActive (true);
		rankManager.instance.myScore.SetActive (false);

		rankManager.instance.score1.text = "" + storageData.instance.spd1;
		rankManager.instance.name1.text = "" + storageData.instance.Sname1;
		rankManager.instance.lv1.text = "" + storageData.instance.Slv1;

		rankManager.instance.score2.text = "" + storageData.instance.spd2;
		rankManager.instance.name2.text = "" + storageData.instance.Sname2;
		rankManager.instance.lv2.text = "" + storageData.instance.Slv2;

		rankManager.instance.score3.text = "" + storageData.instance.spd3;
		rankManager.instance.name3.text = "" + storageData.instance.Sname3;
		rankManager.instance.lv3.text = "" + storageData.instance.Slv3;

		rankManager.instance.score4.text = "" + storageData.instance.spd4;
		rankManager.instance.name4.text = "" + storageData.instance.Sname4;
		rankManager.instance.lv4.text = "" + storageData.instance.Slv4;

		rankManager.instance.score5.text = "" + storageData.instance.spd5;
		rankManager.instance.name5.text = "" + storageData.instance.Sname5;
		rankManager.instance.lv5.text = "" + storageData.instance.Slv5;
	}
}
