using UnityEngine;
using System.Collections;

public class saveNewPlayer : MonoBehaviour {

	public static saveNewPlayer instance;
	private string saveURL = "http://tu-seal.net/kitten/newPlayer.php";
	private string saveCat = "http://tu-seal.net/kitten/newCat.php";

	// Use this for initialization
	void Start () {
	
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void callFunc(){
		Debug.Log ("----call func-------");
	
		StartCoroutine (save());	
	}


	IEnumerator save(){
		Debug.Log ("----save new player-------");
		yield return new WaitForSeconds (1.0f);
		WWWForm form = new WWWForm ();

		if(firstManeger.instance.state == 7){

			form.AddField ("FBID",firstManeger.instance.FBid);
			form.AddField ("Name", newPlayerManager.instance.name);
			form.AddField ("catName" , newPlayerManager.instance.catName);
			form.AddField ("tex", newPlayerManager.instance.texCat);
			form.AddField ("time", System.DateTime.Now.ToString("yyyyMMddHHmmss"));
			
			WWW www = new WWW(saveURL,form);
			yield return www;
			
			
			//check for errors
			if(www.error == null){
				Debug.Log ("----save new player- in if------");
				firstManeger.instance.connect = true;
				ExtractSpheres(www.text);
			}
			else{
				Debug.Log ("----save new player--in else-----");
				Debug.Log("WWW Error: " + www.error);
				firstManeger.instance.connect = false;
			}
		}
		else if(firstManeger.instance.state == 11){

			form.AddField ("playerID",firstManeger.instance.playerId);
			form.AddField ("catName" , firstManeger.instance.catNameBuy);
			form.AddField ("tex", firstManeger.instance.catTexBuy);
			form.AddField ("time", System.DateTime.Now.ToString("yyyyMMddHHmmss"));
			
			WWW www = new WWW(saveCat,form);
			yield return www;
			
			
			//check for errors
			if(www.error == null){
				//Debug.Log ("----save new player- in if------");
				firstManeger.instance.connect = true;
				loadPlayerData.instance.callFunc();
			}
			else{
				//Debug.Log ("----save new player--in else-----");
				Debug.Log("WWW Error: " + www.error);
				firstManeger.instance.connect = false;
			}
		}


	}

	void ExtractSpheres (string json){
		JSONObject jo = new JSONObject (json);
//		Debug.Log (jo);
		
		var s = jo.ToString();
		//Debug.Log (s);
		if (s != "-1") {
			firstManeger.instance.playerId = s;
			Debug.Log ("playerId is " + firstManeger.instance.playerId);

			Debug.Log ("save complete");
			loadPlayerData.instance.callFunc ();
			//lodeCat.instance.callLoadCat();
		} else {
			Debug.Log ("Error Gift is a Mad Girl. !!!!");
		}

//		var sub = s.Substring(1,s.Length-2);




	}
}
