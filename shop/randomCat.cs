using UnityEngine;
using System.Collections;

public class randomCat : MonoBehaviour {

	public void click(){

		Debug.Log ("in click");
		int num = Mathf.FloorToInt(Random.Range (1.0f, 9.0f));

		Debug.Log ("num is "+ num);
		if (num == 1) {
			firstManeger.instance.catTexBuy = "cu_cat_e_col_low";
		}
		else if(num == 2){
			firstManeger.instance.catTexBuy = "cu_cat_c_col_low";
		}
		else if(num == 3){
			firstManeger.instance.catTexBuy = "cu_cat_d_col_low";
		}
		else if(num == 4){
			firstManeger.instance.catTexBuy = "cu_cat_f_col_low";
		}
		else if(num == 5){
			firstManeger.instance.catTexBuy = "cu_cat_g_col_low";
		}
		else if(num == 6){
			firstManeger.instance.catTexBuy = "cu_cat_h_col_low";
		}
		else if(num == 7){
			firstManeger.instance.catTexBuy = "cu_cat_i_col_low";
		}
		else if(num == 8){
			firstManeger.instance.catTexBuy = "cu_cat_col_low";
		}

		Application.LoadLevel ("showCat");
	}
}
