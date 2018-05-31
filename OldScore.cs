using UnityEngine;
using System.Collections;

public class OldScore : MonoBehaviour {

	public static OldScore instance;
	private string saveURL = "http://tu-seal.net/kitten/oldScoreDef.php";
	// Use this for initialization
	void Start () {
		instance = this;

	}

	public void callFunc(){
		StartCoroutine (loadScore());
	}

	IEnumerator loadScore(){
		yield return new WaitForSeconds(0.6f);
		WWWForm form = new WWWForm ();
		form.AddField ("ID",firstManeger.instance.playerId);
		
		WWW www = new WWW(saveURL, form);
		yield return www;
		
		//check for errors
		if(www.error == null){
			firstManeger.instance.connect = true;
			//Debug.Log("WWW Ok!: " + www.data);
			ExtractSpheres (www.text);
		}
		else{
			Debug.Log("WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}

	}


	void ExtractSpheres (string json){
		JSONObject jo = new JSONObject (json);
		//Debug.Log (jo);

		var s = jo.ToString();
		var sub = s.Substring(1,s.Length-2);
		storageData.instance.oldScore = int.Parse (sub);

		//firstManeger.instance.state = 3;
		//Debug.Log ("state is "+firstManeger.instance.state);
		Application.LoadLevel ("cutScreenDef");
		//loadMoney.instance.callMoney ();
	}
}
