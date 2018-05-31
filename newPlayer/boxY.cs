using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class boxY : MonoBehaviour {

	public Canvas s;
	public Canvas o;
	public Canvas box;

	public GameObject b;


	public void click(){

		selectManager.instance.showBox (1);
		s.gameObject.SetActive (false);
		o.gameObject.SetActive (true);
		box.gameObject.SetActive (true);
	}

	public void showCat(){

		int num = Mathf.FloorToInt(Random.Range (1.0f, 3.0f));
		//print (num);

		//cat.SetActive (true);
		if (num == 1) {
			//NPChangeTex.instance.change ("cu_cat_e_col_low");
			newPlayerManager.instance.texCat = "cu_cat_e_col_low";
		}
		else{
			//NPChangeTex.instance.change ("cu_cat_d_col_low");
			newPlayerManager.instance.texCat = "cu_cat_d_col_low";
		}

		Application.LoadLevel ("showCat");
	}


}
