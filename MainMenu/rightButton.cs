﻿using UnityEngine;
using System.Collections;

public class rightButton : MonoBehaviour {

	public Canvas cat1;
	public Canvas cat2;
	public Canvas cat3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click(){

		if(setPopup.instance.isPopup == false && MainManeger.instance.ispopUp == false){
			int c = firstManeger.instance.count;
			int l = firstManeger.instance.limit;
			
			
			if (c == l - 1) {
				firstManeger.instance.count = 0;
				if (c == 1) {
					cat2.gameObject.SetActive (false);
				} 
				else {
					cat3.gameObject.SetActive (false);
				}
				
			} else {
				firstManeger.instance.count++;
				if (c == 0) {
					cat1.gameObject.SetActive (false);
				} else if (c == 1) {
					cat2.gameObject.SetActive (false);
				}
			}
			
			
			if (firstManeger.instance.count == 0) {
				ChangeTexture.instance.change (firstManeger.instance.texcat1);
				cat1.gameObject.SetActive (true);
				
			} 
			else if (firstManeger.instance.count == 1) {
				ChangeTexture.instance.change (firstManeger.instance.texcat2);
				cat2.gameObject.SetActive (true);
			} 
			else if (firstManeger.instance.count == 2) {
				ChangeTexture.instance.change (firstManeger.instance.texcat3);
				cat3.gameObject.SetActive (true);
			}
		}

		}
}
