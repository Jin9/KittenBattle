using UnityEngine;
using System.Collections;

public class boxB : MonoBehaviour {

	public Canvas s;
	public Canvas o;
	public Canvas box;

	public GameObject b;

	public void click(){
		
		selectManager.instance.showBox (3);
		s.gameObject.SetActive (false);
		o.gameObject.SetActive (true);
		box.gameObject.SetActive (true);
	}

	public void showCat(){

		int num = Mathf.FloorToInt(Random.Range (1.0f, 3.0f));

		//cat.SetActive (true);
		if (num == 1) {
			//NPChangeTex.instance.change ("cu_cat_c_col_low");
			newPlayerManager.instance.texCat = "cu_cat_c_col_low";
		}
		else{
			//NPChangeTex.instance.change ("cu_cat_f_col_low");
			newPlayerManager.instance.texCat = "cu_cat_f_col_low";
		}
		Application.LoadLevel ("showCat");
	}
}
