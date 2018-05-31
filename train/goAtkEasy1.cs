using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class goAtkEasy1 : MonoBehaviour {

	public Canvas c;
	public Canvas w;
	public void click(){
		if(setPopup.instance.isPopup == false && trainManeger.instance.ispopup == false){
			if(firstManeger.instance.count == 0){
//				Debug.Log("count = 1");
				if(firstManeger.instance.enC1 >= 5){
					c.gameObject.SetActive(true);
				}
				else{
					w.gameObject.SetActive(true);
				}
			}
			else if(firstManeger.instance.count == 1){

				if(firstManeger.instance.enC2 >= 5){

					c.gameObject.SetActive(true);
				}
				else{
					w.gameObject.SetActive(true);
				}
			}
			else if(firstManeger.instance.count == 2){
				if(firstManeger.instance.enC3 >= 5){

					c.gameObject.SetActive(true);
				}
				else{
					w.gameObject.SetActive(true);
				}
			}


		}

	}
}
