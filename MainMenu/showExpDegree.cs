using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showExpDegree : MonoBehaviour {

	public Canvas c;
	public int count  = 0;

	public void click(){

		if (firstManeger.instance.state == 1) {
			//Debug.Log ("in click");	
			if (MainManeger.instance.ispopUp == false) {
				Debug.Log("in click");
				if (count == 0) {
					count++;
					c.gameObject.SetActive (true);
				}
				else if(count == 1){
					count--;
					c.gameObject.SetActive (false);
				}	
				
			}
			else{
				Debug.Log("in else");
			}
		}
		
		if(firstManeger.instance.state == 2){
			if (trainManeger.instance.ispopup == false) {
				if (count == 0) {
					count++;
					c.gameObject.SetActive (true);
				}
				else if(count == 1){
					count--;
					c.gameObject.SetActive (false);
				}	
				
			}
		}
		if(firstManeger.instance.state == 10){
			
			if (shopManager.instance.ispopup = false) {
				if (count == 0) {
					count++;
					c.gameObject.SetActive (true);
				}
				else if(count == 1){
					count--;
					c.gameObject.SetActive (false);
				}	
				
			}
		}

	}
}
