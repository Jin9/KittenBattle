using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shopManager : MonoBehaviour {

	public static shopManager instance;

	public Canvas expDe;
	public Canvas setting;
	public Canvas cantBuy;
	public Canvas maxCat;
	public Canvas b;

	public int choose = 0;
	public int limit = 0;

	public Canvas food;
	public Canvas maxFood;
	public Canvas ring;

	public bool ispopup = false;

	public Text name;
	public Text degree;
	public Text money;

	public string n1;
	public string n2;
	public string n3;

	public int l1;
	public int l2;
	public int l3;

	public string id1;
	public string id2;
	public string id3;

	// Use this for initialization
	void Start () {
	
		instance = this;
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		Debug.Log ("(shop)state is "+ firstManeger.instance.state);

		name.text = firstManeger.instance.name;
		degree.text = firstManeger.instance.level;
		money.text = ""+firstManeger.instance.money+"  .M";

		expDe.gameObject.SetActive (false);
		setting.gameObject.SetActive (false);
		maxCat.gameObject.SetActive (false);
		cantBuy.gameObject.SetActive (false);
		b.gameObject.SetActive (false);
		food.gameObject.SetActive (false);
		maxFood.gameObject.SetActive (false);
		ring.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		money.text = ""+firstManeger.instance.money+"  .M";
	}
}
