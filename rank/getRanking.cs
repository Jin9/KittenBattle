using UnityEngine;
using System.Collections;

public class getRanking : MonoBehaviour {

	public static getRanking instance;
	private string getURL = "http://tu-seal.net/kitten/getRank.php";
	// Use this for initialization
	void Start () {
	
		instance = this;
	}

	public void callFunc(){
		Debug.Log ("ooooJinoooo ----call func-------");
		
		StartCoroutine (save());	
	}
	
	
	IEnumerator save(){

		yield return new WaitForEndOfFrame ();
		WWWForm form = new WWWForm ();

		form.AddField ("ID", firstManeger.instance.playerId);

		Debug.Log ("ooooJinoooo ----save------");

		//form.AddField ("ID",firstManeger.instance.playerId);

		WWW www = new WWW(getURL,form);
		yield return www;
		
		
		//check for errors
		if(www.error == null){
			//Debug.Log ("----save new player- in if------");
			Debug.Log("ooooJinoooo WWW Ok!: " + www.text);
			ExtractSpheres(www.text);
			firstManeger.instance.connect = true;
		}
		else{
			//Debug.Log ("----save new player--in else-----");
			Debug.Log("ooooJinoooo WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}
	}

	
	void ExtractSpheres (string json){


		JSONObject jo = new JSONObject (json);
		Debug.Log ("ooooJinoooo inJson");
		int num = 0;
		for(int i = 0 ; i < jo.list.Count ;i++){
			var val = (JSONObject) jo.list[i];
			Debug.Log("ooooJinoooo val is "+val.ToString());

			if(i == 0){
				Debug.Log("ooooJinoooo in i = 0");
				var g = val.ToString();
				Debug.Log("ooooJinoooo limit is "+g);
				num = int.Parse(g);
				storageData.instance.rankNum = num;

			}
			else if(i == 1){
				for(int j = 0; j < 3 ; j++){
					if((string)val.keys[j] == "atk" ){
						var s = val.list[j].ToString();
						var sub = s.Substring(1,s.Length-2);
						int x = int.Parse(sub);
						Debug.Log("ooooJinoooo atk is "+x);
						storageData.instance.myAtk = x;
					}
					else if((string)val.keys[j] == "def"){
						var s = val.list[j].ToString();
						var sub = s.Substring(1,s.Length-2);
						int x = int.Parse(sub);
						Debug.Log("ooooJinoooo def is "+x);
						storageData.instance.myDef = x;
					}
					else if((string)val.keys[j] == "spd"){
						var s = val.list[j].ToString();
						var sub = s.Substring(1,s.Length-2);
						int x = int.Parse(sub);
						Debug.Log("ooooJinoooo spd is "+x);
						storageData.instance.mySpd = x;
					}
				}
			}
			else{

				if(num > 4){
					if(i == 14){
						Debug.Log ("ooooJinoooo in i = 14");
						for(int j = 0 ; j < 4 ;j++){
							Debug.Log ("ooooJinoooo key is "+ (string)val.keys[j]);
							
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.atk5 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								
								storageData.instance.Aname5 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								Debug.Log("ooooJinoooo var s is "+s);
								var sub = s.Substring(1,s.Length-2);
								Debug.Log("ooooJinoooo var sub is "+sub);
								int x = int.Parse(sub);
								storageData.instance.Alv5 = x;
								Debug.Log("ooooJinoooo lv is "+x);
							}
						}
					}
					else if(i == 15){
						Debug.Log ("ooooJinoooo in i = 15");
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.def5 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Dname5 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Dlv5 = x;
							}
						}
					}
					else if(i == 16){
						Debug.Log ("ooooJinoooo before in i = 16");
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.spd5 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Sname5 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Slv5 = x;
							}
						}
						Debug.Log ("ooooJinoooo after in i = 16");
					}
				}

				if(num > 3){
					if(i == 11){
						for(int j = 0 ; j < 4 ;j++){
							//Debug.Log ("ooooJinoooo key is "+ (string)val.keys[j]);
							
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.atk4 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								
								storageData.instance.Aname4 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								//Debug.Log("ooooJinoooo var s is "+s);
								var sub = s.Substring(1,s.Length-2);
								//Debug.Log("ooooJinoooo var sub is "+sub);
								int x = int.Parse(sub);
								storageData.instance.Alv4 = x;
								//Debug.Log("ooooJinoooo lv is "+x);
							}
						}
					}
					else if(i == 12){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.def4 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Dname4 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Dlv4 = x;
							}
						}
					}
					else if(i == 13){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.spd4 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Sname4 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Slv4 = x;
							}
						}
					}
				}

				if(num > 2){
					if(i == 8){
						for(int j = 0 ; j < 4 ;j++){
							//Debug.Log ("ooooJinoooo key is "+ (string)val.keys[j]);
							
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.atk3 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								
								storageData.instance.Aname3 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								//Debug.Log("ooooJinoooo var s is "+s);
								var sub = s.Substring(1,s.Length-2);
								//Debug.Log("ooooJinoooo var sub is "+sub);
								int x = int.Parse(sub);
								storageData.instance.Alv3 = x;
								//Debug.Log("ooooJinoooo lv is "+x);
							}
						}
					}
					else if(i == 9){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.def3 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Dname3 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Dlv3 = x;
							}
						}
					}
					else if(i == 10){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.spd3 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Sname3 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Slv3 = x;
							}
						}
					}
				}

				if(num > 1){
					if(i == 5){
						for(int j = 0 ; j < 4 ;j++){
							//Debug.Log ("ooooJinoooo key is "+ (string)val.keys[j]);
							
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.atk2 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								
								storageData.instance.Aname2 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								//Debug.Log("ooooJinoooo var s is "+s);
								var sub = s.Substring(1,s.Length-2);
								//Debug.Log("ooooJinoooo var sub is "+sub);
								int x = int.Parse(sub);
								storageData.instance.Alv2 = x;
								//Debug.Log("ooooJinoooo lv is "+x);
							}
						}
					}
					else if(i == 6){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.def2 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Dname2 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Dlv2 = x;
							}
						}
					}
					else if(i == 7){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.spd2 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Sname2 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Slv2 = x;
							}
						}
					}
				}
				if(num > 0){
					if(i == 2){
						for(int j = 0 ; j < 4 ;j++){
							//Debug.Log ("ooooJinoooo key is "+ (string)val.keys[j]);

							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.atk1 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);

								storageData.instance.Aname1 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								//Debug.Log("ooooJinoooo var s is "+s);
								var sub = s.Substring(1,s.Length-2);
								//Debug.Log("ooooJinoooo var sub is "+sub);
								int x = int.Parse(sub);
								storageData.instance.Alv1 = x;
								//Debug.Log("ooooJinoooo lv is "+x);
							}
						}
					}
					else if(i == 3){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.def1 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Dname1 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Dlv1 = x;
							}
						}
					}
					else if(i == 4){
						for(int j = 0 ; j < 4 ;j++){
							if((string)val.keys[j] == "score" ){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.spd1 = x;
							}
							else if((string)val.keys[j] == "name"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);	
								storageData.instance.Sname1 = sub;
							}
							else if((string)val.keys[j] == "lv"){
								var s = val.list[j].ToString();
								var sub = s.Substring(1,s.Length-2);
								int x = int.Parse(sub);
								storageData.instance.Slv1 = x;
							}
						}
					}
				}

			}

		}

		Application.LoadLevel ("rank");

	}

}
