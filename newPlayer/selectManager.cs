using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class selectManager : MonoBehaviour {
	public static selectManager instance;
	
	public Canvas o;
	public Canvas box;
	public Canvas buy;
	public Canvas select;

	public GameObject y;
	public GameObject r;
	public GameObject b;



	// Use this for initialization
	void Start () {
		instance = this;
		Debug.Log ("(box) state is " + firstManeger.instance.state);

		if(firstManeger.instance.state == 11){
			o.gameObject.SetActive(true);
			box.gameObject.SetActive (false);
			buy.gameObject.SetActive (true);
			select.gameObject.SetActive(false);
		}
		else{
			o.gameObject.SetActive (false);
			box.gameObject.SetActive (false);
			buy.gameObject.SetActive (false);
		}
	
	}

	public void showBox(int num){

		if (num == 1) {
			
			y.SetActive(true);
			r.SetActive(false);
			b.SetActive(false);
		}
		else if(num == 2){
			y.SetActive(false);
			r.SetActive(true);
			b.SetActive(false);
		}
		else if(num == 3){
			y.SetActive(false);
			r.SetActive(false);
			b.SetActive(true);
		}
	}
}
