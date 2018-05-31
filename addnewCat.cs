using UnityEngine;
using System.Collections;

public class addnewCat : MonoBehaviour {

	public static addnewCat instance;

	private string saveURL = "http://tu-seal.net/kitten/newCat.php";
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
		
		Debug.Log ("---------in new cat-----------");
		
		yield return new WaitForEndOfFrame ();
		Debug.Log ("--- after wait---");
		
		WWWForm form = new WWWForm ();
		form.AddField ("FBID", firstManeger.instance.FBid);
		
		Debug.Log ("--- before send----");
		/*WWW www = new WWW(saveURL, form);
		yield return www;
		Debug.Log ("--- after send----");
		
		//check for errors
		if(www.error == null){
			firstManeger.instance.connect = true;
			//Debug.Log("load player WWW Ok!: " + www.data);
		}
		else{
			Debug.Log("load player WWW Error: " + www.error);
			firstManeger.instance.connect = false;
		}
		*/
		
	}
}
