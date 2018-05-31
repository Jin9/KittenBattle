using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class lodeCat : MonoBehaviour {

	public static lodeCat instance;

	private string saveURL = "http://tu-seal.net/kitten/catData.php"; //http://seal-tu.net/Kitten/catData.php
	// Use this for initialization
	
	// Update is called once per frame
	void Start () {
	
		instance = this;
	}

	public void callLoadCat(){
		StartCoroutine (load());
	}



	IEnumerator load(){
		yield return new WaitForSeconds (1.0f);
		WWWForm form = new WWWForm ();
		Debug.Log ("player id is "+firstManeger.instance.playerId);
		form.AddField ("ID",firstManeger.instance.playerId);
		
		WWW www = new WWW(saveURL, form);
		//WWW www = new WWW (saveURL);
		yield return www;

		//check for errors
		if(www.error == null){
			Debug.Log("nnn");
			firstManeger.instance.connect = true;
//			Debug.Log("WWW Ok!: " + www.text);
			ExtractSpheres (www.text);
		}
		else{
			Debug.Log("55");
			Debug.Log("WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}



	}


	void ExtractSpheres (string json){

		JSONObject jo = new JSONObject (json);
		if(jo == null){
			Debug.Log("null");
		}
		else if(jo.list == null){
			Debug.Log("list null");
		}
		else{
			Debug.Log("In loadCat");

			//Debug.Log("jo count "+jo.list.Count);
			for(int i = 0  ;i < jo.list.Count ; i++){
				var val = (JSONObject) jo.list[i];
				//Debug.Log("val is "+val.ToString());

				if(i == 0){
					//Debug.Log("i = "+i);
					var g = val.list[i].ToString();
				Debug.Log("g is "+g);
					firstManeger.instance.limit = int.Parse(g);

				}

				for(int j = 0 ; j < 15 ;j++){
					//Debug.Log(val.keys[j]);
					//Debug.Log(val.list[j]);

					if(i == 1){
						if((string)val.keys[j] == "name" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.nameC1 = sub.ToString();
							Debug.Log("name c1 is "+firstManeger.instance.nameC1);
							
						}
						else if((string)val.keys[j] == "level" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							//Debug.Log("lv is "+s);

							var sub = s.Substring(1,s.Length-2);
							//Debug.Log("sub " + sub);
							int x = int.Parse(sub);
							//Debug.Log("in int lv is "+ x);
							//firstManeger.instance.levelC1 = sub.ToString();
							firstManeger.instance.levelC1 = x;
						}
						else if((string)val.keys[j] == "hp" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.hpC1 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "exp" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.expC1 = x;
							
						}
						else if((string)val.keys[j] == "en" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.enC1 = x;
							
						}
						else if((string)val.keys[j] == "atk" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.atkC1 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "def" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.defC1 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "spd" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.spdC1 = sub.ToString();
							
						}
			
						else if((string)val.keys[j] == "catid" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.catid1 = sub.ToString();
						}

						else if((string)val.keys[j] == "texture"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.texcat1 = sub;
						}
						else if((string)val.keys[j] == "expFull"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							Debug.Log("expFull is "+x);
							firstManeger.instance.expFullC1 = x;
						}
						else if((string)val.keys[j] == "enFull"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.enFullC1 = x;
						}
						else if((string)val.keys[j] == "time"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							Debug.Log ("old time is "+sub.ToString());
							if(sub != "0"){
								int year = int.Parse(sub.Substring(0,4));
								int  month = int.Parse(sub.Substring(4,2));
								int day = int.Parse(sub.Substring(6,2));
								int hr = int.Parse(sub.Substring(8,2));
								int min= int.Parse(sub.Substring(10,2));
								
								string newtime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
								Debug.Log ("new time is "+newtime);
								int year2 = int.Parse(newtime.Substring(0,4));
								int  month2 = int.Parse(newtime.Substring(4,2));
								int day2 = int.Parse(newtime.Substring(6,2));
								int hr2 = int.Parse(newtime.Substring(8,2));
								int min2= int.Parse(newtime.Substring(10,2));
								
								DateTime start = new DateTime (year , month ,day , hr , min ,00);
								DateTime end = new DateTime (year2 , month2 ,day2 ,hr2 ,min2 ,00);
								TimeSpan diff = end - start;
								Debug.Log(diff);
								int diff2 = (diff.Days*24*60) + (diff.Hours*60) + diff.Minutes;
								
								firstManeger.instance.enC1 += diff2/3;
								if(firstManeger.instance.enC1 > firstManeger.instance.enFullC1){
									firstManeger.instance.enC1 = firstManeger.instance.enFullC1;
								}
							}

						}
						else if((string)val.keys[j] == "food"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.foodC1 = sub;
						}
						else if((string)val.keys[j] == "ring"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.ringC1 = sub;
						}


					}

					else if(i == 2 && firstManeger.instance.limit > 1){

						if((string)val.keys[j] == "name" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.nameC2 = sub.ToString();
							Debug.Log("name c2 is "+firstManeger.instance.nameC2);
							
						}
						else if((string)val.keys[j] == "level" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							//Debug.Log("lv2 is "+sub);
							int x = int.Parse(sub);
							firstManeger.instance.levelC2 = x;
							
						}
						else if((string)val.keys[j] == "hp" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.hpC2 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "exp" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.expC2 = x;
							
						}
						else if((string)val.keys[j] == "en" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.enC2 = x;
							
						}
						else if((string)val.keys[j] == "atk" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.atkC2 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "def" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.defC2 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "spd" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.spdC2 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "catid" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.catid2 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "texture"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							
							//ChangeTexture.instance.change(sub);
							//firstManeger.instance.setTexCat2(sub);
							firstManeger.instance.texcat2 = sub;
						}
						else if((string)val.keys[j] == "expFull"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.expFullC2 = x;
						}
						else if((string)val.keys[j] == "enFull"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.enFullC2 = x;
						}
						else if((string)val.keys[j] == "time"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							Debug.Log ("old time is "+sub.ToString());
							if(sub != "0"){
								int year = int.Parse(sub.Substring(0,4));
								int  month = int.Parse(sub.Substring(4,2));
								int day = int.Parse(sub.Substring(6,2));
								int hr = int.Parse(sub.Substring(8,2));
								int min= int.Parse(sub.Substring(10,2));
								
								string newtime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
								Debug.Log ("new time is "+newtime);
								int year2 = int.Parse(newtime.Substring(0,4));
								int  month2 = int.Parse(newtime.Substring(4,2));
								int day2 = int.Parse(newtime.Substring(6,2));
								int hr2 = int.Parse(newtime.Substring(8,2));
								int min2= int.Parse(newtime.Substring(10,2));
								
								DateTime start = new DateTime (year , month ,day , hr , min ,00);
								DateTime end = new DateTime (year2 , month2 ,day2 ,hr2 ,min2 ,00);
								TimeSpan diff = end - start;
								Debug.Log(diff);
								int diff2 = (diff.Days*24*60) + (diff.Hours*60) + diff.Minutes;
								
								firstManeger.instance.enC2 += diff2/3;
								if(firstManeger.instance.enC2 > firstManeger.instance.enFullC2){
									firstManeger.instance.enC2 = firstManeger.instance.enFullC2;
								}
							}

						}
						else if((string)val.keys[j] == "food"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.foodC2 = sub;
						}
						else if((string)val.keys[j] == "ring"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.ringC2 = sub;
						}

					}

					else if(i == 3 && firstManeger.instance.limit > 2){
						
						if((string)val.keys[j] == "name" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.nameC3 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "level" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.levelC3 = x;
							
						}
						else if((string)val.keys[j] == "hp" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.hpC3 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "exp" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.expC3 = x;
							
						}
						else if((string)val.keys[j] == "en" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.enC3 = x;
							
						}
						else if((string)val.keys[j] == "atk" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.atkC3 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "def" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.defC3 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "spd" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.spdC3 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "catid" ){
							//name.text = val.ToString();
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.catid3 = sub.ToString();
							
						}
						else if((string)val.keys[j] == "texture"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);

							firstManeger.instance.texcat3 = sub;
							//ChangeTexture.instance.change(sub);
							//firstManeger.instance.setTexCat3(sub);
						}
						else if((string)val.keys[j] == "expFull"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.expFullC3 = x;
						}
						else if((string)val.keys[j] == "enFull"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							int x = int.Parse(sub);
							firstManeger.instance.enFullC3 = x;
						}
						else if((string)val.keys[j] == "time"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							Debug.Log ("old time is "+sub.ToString());
							if(sub != "0"){
								int year = int.Parse(sub.Substring(0,4));
								int  month = int.Parse(sub.Substring(4,2));
								int day = int.Parse(sub.Substring(6,2));
								int hr = int.Parse(sub.Substring(8,2));
								int min= int.Parse(sub.Substring(10,2));
								
								string newtime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
								Debug.Log ("new time is "+newtime);
								int year2 = int.Parse(newtime.Substring(0,4));
								int  month2 = int.Parse(newtime.Substring(4,2));
								int day2 = int.Parse(newtime.Substring(6,2));
								int hr2 = int.Parse(newtime.Substring(8,2));
								int min2= int.Parse(newtime.Substring(10,2));
								
								DateTime start = new DateTime (year , month ,day , hr , min ,00);
								DateTime end = new DateTime (year2 , month2 ,day2 ,hr2 ,min2 ,00);
								TimeSpan diff = end - start;
								Debug.Log(diff);
								int diff2 = (diff.Days*24*60) + (diff.Hours*60) + diff.Minutes;
								
								firstManeger.instance.enC3 += diff2/3;
								if(firstManeger.instance.enC3 > firstManeger.instance.enFullC3){
									firstManeger.instance.enC3 = firstManeger.instance.enFullC3;
								}
							}

						}
						else if((string)val.keys[j] == "food"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.foodC3 = sub;
						}
						else if((string)val.keys[j] == "ring"){
							var s = val.list[j].ToString();
							var sub = s.Substring(1,s.Length-2);
							firstManeger.instance.ringC3 = sub;
						}
					}
				}


				//Debug.Log("-----End-----");
			}
		}
	

		//firstManeger.instance.state = 1;
		Debug.Log ("load cat complete");
		//loadPlayerData.instance.callFunc ();
		if (firstManeger.instance.state == 10) {
		
			Application.LoadLevel("shop");
		}
		else{

			Application.LoadLevel ("mainmenu");
		}

		//MainManeger.instance.setScene ();


		//Debug.Log ("state is "+ firstManeger.instance.state);
	}
}
