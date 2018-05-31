using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loadPlayerData : MonoBehaviour {


	public static loadPlayerData instance;

	private string saveURL = "http://tu-seal.net/kitten/playerData.php";
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void callFunc(){
		StartCoroutine (load());
	}

	IEnumerator load(){

		Debug.Log ("---------in load player-----------");

		yield return new WaitForEndOfFrame ();
		Debug.Log ("--- after wait---");

		WWWForm form = new WWWForm ();
		form.AddField ("FBID", firstManeger.instance.FBid);
		          
		Debug.Log ("--- before send----");
		WWW www = new WWW(saveURL, form);
		yield return www;
		Debug.Log ("--- after send----");

		//check for errors
		if(www.error == null){
			firstManeger.instance.connect = true;
			//Debug.Log("load player WWW Ok!: " + www.data);
			PlayerLoad (www.text);
		}
		else{
			Debug.Log("load player WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}


	}

	void PlayerLoad (string json){

		Debug.Log ("---------- in jason ----------");
		//print ("in jason");
		JSONObject jo = new JSONObject (json);
		if(jo == null){
			Debug.Log("null");
		}
		else{
			Debug.Log("In loadPlayer");
			for(int i = 0 ; i < jo.list.Count ; i++){

				var val = (JSONObject) jo.list[i];
				if(val.ToString().Length == 2){ // search data base = null
					Debug.Log("null");
					firstManeger.instance.state = 6;
					Application.LoadLevel("newPlayer");
				}

				else{
					if((string)jo.keys[i] == "name" ){
						//name.text = val.ToString();
						var s = val.ToString();
						var sub = s.Substring(1,s.Length-2);
						firstManeger.instance.name = sub.ToString();
						
					}
					else if((string)jo.keys[i] == "level" ){
						//degree.text = val.ToString();
						var s = val.ToString();
						var sub = s.Substring(1,s.Length-2);
						firstManeger.instance.level = sub.ToString();
					}
					else if((string)jo.keys[i] == "money" ){
						//money.text = val.ToString() + " M.";
						var s = val.ToString();
						var sub = s.Substring(1,s.Length-2);

						int x = int.Parse(sub);
						firstManeger.instance.money = x;
					}
					else if((string)jo.keys[i] == "id"){
						var s = val.ToString();
						var sub = s.Substring(1,s.Length-2);
						firstManeger.instance.playerId = sub.ToString();
						Debug.Log("p is "+ firstManeger.instance.playerId);
					}
					else if((string)jo.keys[i] == "exp" ){
						//money.text = val.ToString() + " M.";
						var s = val.ToString();
						var sub = s.Substring(1,s.Length-2);
						
						int x = int.Parse(sub);
						firstManeger.instance.expP = x;
					}
					else if((string)jo.keys[i] == "expFull" ){
						//money.text = val.ToString() + " M.";
						var s = val.ToString();
						var sub = s.Substring(1,s.Length-2);
						
						int x = int.Parse(sub);
						firstManeger.instance.expFullP = x;
					}

					Debug.Log ("load player complete");
					lodeCat.instance.callLoadCat();
					//Application.LoadLevel ("mainmenu");
				}
			}

		}
		//firstManeger.instance.state = 1;
		//MainManeger.instance.setScene ();
		//Debug.Log ("load player complete");

	}
}
