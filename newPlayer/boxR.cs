using UnityEngine;
using System.Collections;

public class boxR : MonoBehaviour {

	public Canvas s;
	public Canvas o;
	public Canvas box;

	public GameObject b;



	public void click(){
		
		selectManager.instance.showBox (2);
		s.gameObject.SetActive (false);
		o.gameObject.SetActive (true);
		box.gameObject.SetActive (true);
	}

	public void showCat(){

		int num = Mathf.FloorToInt(Random.Range (1.0f, 3.0f));
		Debug.Log (num);
		if (num == 1) {
	
			//NPChangeTex.instance.change ("cu_cat_h_col_low");
			newPlayerManager.instance.texCat = "cu_cat_h_col_low";
		}

		else{
			//NPChangeTex.instance.change ("cu_cat_i_col_low");
			newPlayerManager.instance.texCat = "cu_cat_i_col_low";  // error here
		}

		Application.LoadLevel ("showCat");

	}
}
