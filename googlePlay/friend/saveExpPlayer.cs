using UnityEngine;
using System.Collections;

public class saveExpPlayer : MonoBehaviour {

	private string SaveExp = "http://tu-seal.net/kitten/saveExpBattle.php";
	public static saveExpPlayer instance;

	// Use this for initialization
	void Start () {
	
		instance = this;
	}
	
	public void callFunc() {
		//Debug.Log (Player.instance.oldScore);
		Debug.Log ("ooooJinoooo in callFunc saveExpPlayer");
		StartCoroutine (SendData());
		
	}
	
	IEnumerator SendData(){
		//Debug.Log ("save data");

		Debug.Log ("ooooJinoooo in SendData");
		yield return new WaitForSeconds (1.0f);
		WWWForm form = new WWWForm ();
		form.AddField ("ID",firstManeger.instance.playerId);
		form.AddField ("exp",firstManeger.instance.expP);
		form.AddField ("expFull",firstManeger.instance.expFullP);

		Debug.Log ("state is "+ firstManeger.instance.state);
		if(firstManeger.instance.battle == 0){ //lose
			form.AddField("expAdd",20);
		}
		else{
			form.AddField("expAdd",100);
		}

		Debug.Log ("ooooJinoooo in SendData : "+SaveExp);
		WWW w = new WWW(SaveExp, form);
		yield return w;
		
		//check for errors
		if(w.error == null){
			Debug.Log("WWW Ok!: " + w.data);
			loadPlayerData.instance.callFunc();
		}
		else{
			Debug.Log("WWW Error: " + w.error);
		}
	}

}
