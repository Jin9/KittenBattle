using UnityEngine;
using System.Collections;

public class deleteCat : MonoBehaviour {

	public static deleteCat instance;
	private string delURL = "http://tu-seal.net/kitten/delCat.php";

	// Use this for initialization
	void Start () {
	
		instance = this;
	}
	
	public void callFunc(){
		StartCoroutine (delete());
	}
	
	IEnumerator delete(){
		yield return new WaitForSeconds(0.6f);
		WWWForm form = new WWWForm ();

		if (firstManeger.instance.count == 0) {
			form.AddField("CatId",firstManeger.instance.catid1);
			Debug.Log (firstManeger.instance.catid1);
		}
		else if(firstManeger.instance.count == 1){
			form.AddField("CatId",firstManeger.instance.catid2);
			Debug.Log (firstManeger.instance.catid2);
		}
		else if(firstManeger.instance.count == 2){
			form.AddField("CatId",firstManeger.instance.catid3);
			Debug.Log (firstManeger.instance.catid3);
		}
		
		WWW www = new WWW(delURL, form);
		yield return www;
		
		//check for errors
		if(www.error == null){
			firstManeger.instance.connect = true;
			firstManeger.instance.state = 1;
			lodeCat.instance.callLoadCat();
			//Debug.Log("WWW Ok!: " + www.data);
		}
		else{
			Debug.Log("WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}
		
	}
}
