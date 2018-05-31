using UnityEngine;
using System.Collections;

public class cancelButton : MonoBehaviour {

	public Canvas c;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void clickCancel(){
		if (firstManeger.instance.state == 1) {
			MainManeger.instance.ispopUp = false;	
		}
		if(firstManeger.instance.state == 2){
			trainManeger.instance.ispopup = false;
		}
		if(firstManeger.instance.state == 10){
			shopManager.instance.ispopup = false;
		}
	
		c.gameObject.SetActive (false);
		


	}
}
