using UnityEngine;
using System.Collections;

public class setting : MonoBehaviour {
	public Canvas set;

	public void clickSetting(){
		if (firstManeger.instance.state == 1) {
			MainManeger.instance.ispopUp = true;	
		}
		if(firstManeger.instance.state == 2){
			trainManeger.instance.ispopup = true;
		}
		if(firstManeger.instance.state == 10){
			shopManager.instance.ispopup = true;
		}
		set.gameObject.SetActive (true);

	}
}
