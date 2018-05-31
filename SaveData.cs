using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {

	public static SaveData instance;
	private string saveDef = "http://tu-seal.net/kitten/saveDef.php";
	private string saveAtk = "http://tu-seal.net/kitten/saveAtk.php";
	private string saveSpd = "http://tu-seal.net/kitten/saveSpd.php";
	// Use this for initialization

	void Start(){
		instance = this;
	}

	public void Over() {
		//Debug.Log (Player.instance.oldScore);
		
		StartCoroutine (SendData());
		
	}
	
	IEnumerator SendData(){
		//Debug.Log ("save data");
		
		yield return new WaitForEndOfFrame ();
		WWWForm form = new WWWForm ();
		form.AddField ("ID",firstManeger.instance.playerId);
		
		Debug.Log ("state is "+ firstManeger.instance.state);
		
		//form.AddField ("FBID",firstManeger.instance.FBid);
		if (firstManeger.instance.state == 3) { //def
			if (PlayerDef.instance.oldScore < PlayerDef.instance.score) { //bestscore
				form.AddField ("Def", PlayerDef.instance.score);
			}
			else{
				form.AddField ("Def", PlayerDef.instance.oldScore);
			}
		}
		else if(firstManeger.instance.state == 4){//atk
			Debug.Log("save data");
			if (PlayerAtk.instance.oldScore < PlayerAtk.instance.score) { //bestscore
				form.AddField ("Atk", PlayerAtk.instance.score);
			}
			else{
				form.AddField ("Atk", PlayerAtk.instance.oldScore);
			}
		}
		else if(firstManeger.instance.state == 8){ //spd
			Debug.Log("save data");
			
			if (SpdManager.instance.oldScore < SpdManager.instance.s) { //bestscore
				form.AddField ("Spd", SpdManager.instance.s);
			}
			else{
				form.AddField ("Spd", SpdManager.instance.oldScore);
			}
			
		}
		
		if (firstManeger.instance.count == 0) {
			form.AddField("CatId",firstManeger.instance.catid1);
			form.AddField ("expFull",firstManeger.instance.expFullC1);
			form.AddField ("exp",firstManeger.instance.expC1);
			form.AddField ("en",firstManeger.instance.enC1);
		}
		else if(firstManeger.instance.count == 1){
			form.AddField("CatId",firstManeger.instance.catid2);
			form.AddField ("expFull",firstManeger.instance.expFullC2);
			form.AddField ("exp",firstManeger.instance.expC2);
			form.AddField ("en",firstManeger.instance.enC2);
		}
		else if(firstManeger.instance.count == 2){
			form.AddField("CatId",firstManeger.instance.catid3);
			form.AddField ("expFull",firstManeger.instance.expFullC3);
			form.AddField ("exp",firstManeger.instance.expC3);
			form.AddField ("en",firstManeger.instance.enC3);
		}
		
		
		if (firstManeger.instance.state == 3) {
			WWW w = new WWW(saveDef, form);
			yield return w;
			
			//check for errors
			if(w.error == null){
				Debug.Log("WWW Ok!: " + w.data);
			}
			else{
				Debug.Log("WWW Error: " + w.error);
			}
		}
		else if(firstManeger.instance.state == 4){
			WWW w = new WWW(saveAtk, form);
			yield return w;
			
			//check for errors
			if(w.error == null){
				Debug.Log("WWW Ok!: " + w.data);
			}
			else{
				Debug.Log("WWW Error: " + w.error);
			}
		}
		else if(firstManeger.instance.state == 8){
			WWW w = new WWW(saveSpd, form);
			yield return w;
			
			//check for errors
			if(w.error == null){
				Debug.Log("WWW Ok!: " + w.data);
			}
			else{
				Debug.Log("WWW Error: " + w.error);
			}
		}
		
		
		
	}
}
