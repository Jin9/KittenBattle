using UnityEngine;
using System.Collections;

public class easyEn : MonoBehaviour {

	public static easyEn instance;
	private string saveURL = "http://tu-seal.net/kitten/easyEn.php";
	// Use this for initialization
	void Start () {
		instance = this;
	}

	public void callFunc(){
		Debug.Log ("in call func");
		StartCoroutine (ChangeEn());
	}

	IEnumerator ChangeEn(){
		Debug.Log ("in change");

		yield return new WaitForEndOfFrame ();
		WWWForm form = new WWWForm ();
		Debug.Log ("cout is "+firstManeger.instance.count);

		if (firstManeger.instance.count == 0) {
			form.AddField ("catID",firstManeger.instance.catid1);
			form.AddField ("en", firstManeger.instance.enC1);
		} else if (firstManeger.instance.count == 1) {
			form.AddField ("catID",firstManeger.instance.catid2);	
			form.AddField ("en", firstManeger.instance.enC2);
		} else if (firstManeger.instance.count == 2) {
			form.AddField ("catID",firstManeger.instance.catid3);
			form.AddField ("en", firstManeger.instance.enC3);
		}
		form.AddField ("time", System.DateTime.Now.ToString("yyyyMMddHHmmss"));

		Debug.Log ("complete");

		WWW www = new WWW(saveURL, form);
		yield return www;
		
		//check for errors
		if(www.error == null){
			firstManeger.instance.connect = true;
			Debug.Log("WWW Ok!: " + www.data);
		}
		else{
			Debug.Log("WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}
	
	}

}
