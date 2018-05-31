using UnityEngine;
using System.Collections;

public class enUp : MonoBehaviour {

	public static enUp instance;
	int c;
	private string saveEn = "http://tu-seal.net/kitten/enUp.php";
	private string saveEn2 = "http://tu-seal.net/kitten/enUp2.php";
	private string saveEn3 = "http://tu-seal.net/kitten/enUp3.php";
	// Use this for initialization
	void Start () {
		instance = this;
	}

	public void callFunc(int count){
		c = count;
		Debug.Log ("count is "+c);
		if (c == 1) {
			StartCoroutine (load());	
		}
		else if(c == 2){
			StartCoroutine (load2());
		}
		else if(c == 3){
			StartCoroutine (load3());
		}

	}
	IEnumerator load3(){
		yield return new WaitForSeconds (1.0f);
		WWWForm form = new WWWForm ();
		//Debug.Log ("count2 is "+c);
		//Debug.Log ("player id is "+firstManeger.instance.playerId);
		Debug.Log ("in 3");
		form.AddField ("en",firstManeger.instance.enC3);
		form.AddField ("catID",firstManeger.instance.catid3);
		form.AddField ("time", System.DateTime.Now.ToString("yyyyMMddHHmmss"));
		
		
		WWW www = new WWW(saveEn3, form);
		//WWW www = new WWW (saveURL);
		yield return www;
		
		//check for errors
		if(www.error == null){
			//Debug.Log("nnn");
			firstManeger.instance.connect = true;
			//Debug.Log("WWW Ok!: " + www.text);
		}
		else{
			//Debug.Log("55");
			Debug.Log("WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}
	}

	IEnumerator load2(){
		yield return new WaitForSeconds (1.0f);
		WWWForm form = new WWWForm ();
		//Debug.Log ("count2 is "+c);
		//Debug.Log ("player id is "+firstManeger.instance.playerId);
		Debug.Log ("in 2");
		form.AddField ("en",firstManeger.instance.enC2);
		form.AddField ("catID",firstManeger.instance.catid2);
		form.AddField ("time", System.DateTime.Now.ToString("yyyyMMddHHmmss"));

		
		WWW www = new WWW(saveEn2, form);
		//WWW www = new WWW (saveURL);
		yield return www;
		
		//check for errors
		if(www.error == null){
			//Debug.Log("nnn");
			firstManeger.instance.connect = true;
			//Debug.Log("WWW Ok!: " + www.text);
		}
		else{
			//Debug.Log("55");
			Debug.Log("WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}
	}

	IEnumerator load(){
		yield return new WaitForSeconds (1.0f);
		WWWForm form = new WWWForm ();
		Debug.Log ("count2 is "+c);
		//Debug.Log ("player id is "+firstManeger.instance.playerId);
	
		Debug.Log (System.DateTime.Now.ToString("yyyyMMddHHmmss"));
		Debug.Log ("in 1");
		form.AddField ("en",firstManeger.instance.enC1);
		form.AddField ("catID",firstManeger.instance.catid1);
		form.AddField ("time", System.DateTime.Now.ToString("yyyyMMddHHmmss"));

	
		WWW www = new WWW(saveEn, form);
		//WWW www = new WWW (saveURL);
		yield return www;
		
		//check for errors
		if(www.error == null){
			//Debug.Log("nnn");
			firstManeger.instance.connect = true;
			//Debug.Log("WWW Ok!: " + www.text);
		}
		else{
			//Debug.Log("55");
			Debug.Log("WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}
		
		
		
	}
}
