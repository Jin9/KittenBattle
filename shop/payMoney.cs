using UnityEngine;
using System.Collections;

public class payMoney : MonoBehaviour {

	public static payMoney instance;
	int p = 0;
	int func = 0; // 0 = buycat , 1 = buyFood, 2 = buyRing
	private string payURL = "http://tu-seal.net/kitten/payMoney.php";
	private string payFood = "http://tu-seal.net/kitten/payFood.php";
	private string payRing = "http://tu-seal.net/kitten/payRing.php";

	// Use this for initialization
	void Start () {
	
		instance = this;
	}

	public void callFunc(int PayMon ,int f){

		p = PayMon;
		func = f;
		StartCoroutine (pay ());
	}
	
	IEnumerator pay(){
		//yield return new WaitForSeconds (1.0f);
		yield return new WaitForEndOfFrame ();
		WWWForm form = new WWWForm ();

		if (func == 0) {
			form.AddField ("playerID" , firstManeger.instance.playerId);
			form.AddField ("pay" , p);
			
			WWW www = new WWW(payURL ,form);
			yield return www;	
		
			//check for errors
			if(www.error == null){
				
				firstManeger.instance.connect = true;
			}
			else{
				Debug.Log("WWW Error: " + www.error);
				firstManeger.instance.connect = false;
			}
		}

		else if(func == 1){

			form.AddField ("playerID" , firstManeger.instance.playerId);
			form.AddField ("pay" , p);

			if(shopManager.instance.choose == 0){
				form.AddField("catID" , shopManager.instance.id1);
			}
			else if(shopManager.instance.choose == 1){
				form.AddField("catID" , shopManager.instance.id2);
			}
			else if(shopManager.instance.choose == 2){
				form.AddField("catID" , shopManager.instance.id3);
			}
			
			WWW www = new WWW(payFood ,form);
			yield return www;	
			
			//check for errors
			if(www.error == null){
				
				firstManeger.instance.connect = true;
			}
			else{
				Debug.Log("WWW Error: " + www.error);
				firstManeger.instance.connect = false;
			}

		}

		else if(func == 2){
			
			form.AddField ("playerID" , firstManeger.instance.playerId);
			form.AddField ("pay" , p);
			
			if(shopManager.instance.choose == 0){
				form.AddField("catID" , shopManager.instance.id1);
			}
			else if(shopManager.instance.choose == 1){
				form.AddField("catID" , shopManager.instance.id2);
			}
			else if(shopManager.instance.choose == 2){
				form.AddField("catID" , shopManager.instance.id3);
			}
			
			WWW www = new WWW(payRing ,form);
			yield return www;	
			
			//check for errors
			if(www.error == null){
				
				firstManeger.instance.connect = true;
			}
			else{
				Debug.Log("WWW Error: " + www.error);
				firstManeger.instance.connect = false;
			}
			
		}





	}
}
