using UnityEngine;
using System.Collections;

public class oldScoreAtk : MonoBehaviour {

	public static oldScoreAtk instance;
	private string saveURL = "http://tu-seal.net/kitten/oldScoreAtk.php";

	// Use this for initialization
	void Start () {
		instance = this;
	}

	public void callFunc(){
		StartCoroutine (loadScore());
		Debug.Log ("function");
	}
	
	IEnumerator loadScore(){ //easy
		yield return new WaitForSeconds (1.0f);
		WWWForm form = new WWWForm ();
		Debug.Log ("in load score "+firstManeger.instance.playerId);
		form.AddField ("ID",firstManeger.instance.playerId);

		if (firstManeger.instance.count == 0) {
			form.AddField ("catID",firstManeger.instance.catid1);
		} else if (firstManeger.instance.count == 1) {
			form.AddField ("catID",firstManeger.instance.catid2);	
		} else if (firstManeger.instance.count == 2) {
			form.AddField ("catID",firstManeger.instance.catid3);	
		}

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

		//Debug.Log ("old score "+sub);
		storageData.instance.oldScore = int.Parse (sub);
		
		//firstManeger.instance.state = 3;
		//Debug.Log ("state is "+firstManeger.instance.state);
		print ("load complete");
		Application.LoadLevel ("cutScreenAtk");
		//loadMoney.instance.callMoney ();
	}

}
