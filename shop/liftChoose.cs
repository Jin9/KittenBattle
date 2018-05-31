using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class liftChoose : MonoBehaviour {

	public Text name;
	public Text lv;
	public void click(){

		Debug.Log ("in lift click");
		int c = shopManager.instance.choose;
		int l = shopManager.instance.limit;


		if (c == 0) {
			shopManager.instance.choose = l - 1;
		}
		else{
			shopManager.instance.choose--;
		}

		if (shopManager.instance.choose == 0) {
			name.text = shopManager.instance.n1;
			lv.text = ""+shopManager.instance.l1;
		}
		else if(shopManager.instance.choose == 1){
			name.text = shopManager.instance.n2;
			lv.text = ""+shopManager.instance.l2;
		}
		else if(shopManager.instance.choose == 2){
			name.text = shopManager.instance.n3;
			lv.text = ""+shopManager.instance.l3;
		}
	}
}
