using UnityEngine;
using System.Collections;

public class buy : MonoBehaviour {

	public Canvas cantBuy;
	public Canvas maxCat;
	public Canvas b;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickBuy(){

		if (shopManager.instance.ispopup == false) {

			if (firstManeger.instance.limit == 3) {
				maxCat.gameObject.SetActive(true);
				shopManager.instance.ispopup = true;
			}
			else if(firstManeger.instance.money < 1000){
				cantBuy.gameObject.SetActive(true);
				shopManager.instance.ispopup = true;
			}
			else{
				b.gameObject.SetActive(true);
				shopManager.instance.ispopup = true;
			}
		}

	}
}
