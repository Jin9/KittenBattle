using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainManeger : MonoBehaviour {

	public bool ispopUp = false;
	public Canvas cat1;
	public Canvas cat2;
	public Canvas cat3;
	public Canvas set;
	public Canvas notRelease;
	public Canvas release;
	public Canvas ExpDegree;

	public Text name;
	public Text degree;
	public Text money;

	public GameObject food;
	public GameObject ring;

	//cat data
	public Text nameC1;
	public Text levelC1;
	public Text enC1;
	public Text expC1;
	public Text hpC1;
	public Text atkC1;
	public Text defC1;
	public Text spdC1;
	public Text expFullC1;
	public Text enFullC1;
	
	public Text nameC2;
	public Text levelC2;
	public Text enC2;
	public Text expC2;
	public Text hpC2;
	public Text atkC2;
	public Text defC2;
	public Text spdC2;
	public Text expFullC2;
	public Text enFullC2;
	
	public Text nameC3;
	public Text levelC3;
	public Text enC3;
	public Text expC3;
	public Text hpC3;
	public Text atkC3;
	public Text defC3;
	public Text spdC3;
	public Text expFullC3;
	public Text enFullC3;

	public Text expDe;



	public AudioClip c;

	public RawImage ec1; // exp
	public RawImage nc1; //en
	public RawImage ec2; // exp
	public RawImage nc2; //en
	public RawImage ec3; // exp
	public RawImage nc3; //en

	float timec1 = 180.0f;
	float timec2 = 180.0f;
	float timec3 = 180.0f;

	float timeF1 = 120.0f;
	float timeF2 = 120.0f;
	float timeF3 = 120.0f;

	public static MainManeger instance;

	// Use this for initialization
	void Start () {
		instance = this;
		Time.timeScale = 1.0f;

		expDe.text = "" + firstManeger.instance.expP + " / " + firstManeger.instance.expFullP;
		food.SetActive (false);
		ring.SetActive (false);
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		set.gameObject.SetActive (false);
		notRelease.gameObject.SetActive (false);
		release.gameObject.SetActive (false);
		ExpDegree.gameObject.SetActive (false);

		name.text = firstManeger.instance.name;
		degree.text = firstManeger.instance.level;
		money.text = ""+firstManeger.instance.money +"  .M";

		Debug.Log ("(Main)state is " + firstManeger.instance.state);
		Debug.Log ("(Main)cat is "+ firstManeger.instance.count);

		if (firstManeger.instance.limit >= 1) {
			nameC1.text = firstManeger.instance.nameC1;
			levelC1.text = ""+firstManeger.instance.levelC1;
			enC1.text = ""+firstManeger.instance.enC1;
			enFullC1.text = "/ "+firstManeger.instance.enFullC1;
			expC1.text = ""+firstManeger.instance.expC1;
			expFullC1.text = "/ "+firstManeger.instance.expFullC1;
			hpC1.text = firstManeger.instance.hpC1;
			atkC1.text = firstManeger.instance.atkC1;
			defC1.text = firstManeger.instance.defC1;
			spdC1.text = firstManeger.instance.spdC1;	
		}
		if(firstManeger.instance.limit >= 2){
			nameC2.text = firstManeger.instance.nameC2;
			levelC2.text = ""+firstManeger.instance.levelC2;
			enC2.text = ""+firstManeger.instance.enC2;
			enFullC2.text = "/ "+firstManeger.instance.enFullC2;
			expC2.text = ""+firstManeger.instance.expC2;
			expFullC2.text = "/ "+firstManeger.instance.expFullC2;
			hpC2.text = firstManeger.instance.hpC2;
			atkC2.text = firstManeger.instance.atkC2;
			defC2.text = firstManeger.instance.defC2;
			spdC2.text = firstManeger.instance.spdC2;
		}
		if(firstManeger.instance.limit >= 3){
			nameC3.text = firstManeger.instance.nameC3;
			levelC3.text = ""+firstManeger.instance.levelC3;
			enC3.text = ""+firstManeger.instance.enC3;
			enFullC3.text = "/ "+firstManeger.instance.enFullC3;
			expC3.text = ""+firstManeger.instance.expC3;
			expFullC3.text = "/ "+firstManeger.instance.expFullC3;
			hpC3.text = firstManeger.instance.hpC3;
			atkC3.text = firstManeger.instance.atkC3;
			defC3.text = firstManeger.instance.defC3;
			spdC3.text = firstManeger.instance.spdC3;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		setScene ();

		if(firstManeger.instance.enC1 < firstManeger.instance.enFullC1) {

			if(firstManeger.instance.foodC1 == "0"){
				timec1 -= Time.deltaTime;
				if(timec1 < 0){
					firstManeger.instance.enC1 += 1;
					enC1.text = ""+firstManeger.instance.enC1;
					enUp.instance.callFunc(1);
					timec1 = 180.0f;
				}
			}
			else{
				timeF1 -= Time.deltaTime;
				if(timeF1 < 0){
					firstManeger.instance.enC1 += 1;
					enC1.text = ""+firstManeger.instance.enC1;
					enUp.instance.callFunc(1);
					timeF1 = 120.0f;
				}
			}

		}

		if(firstManeger.instance.enC2 < firstManeger.instance.enFullC2){

			if(firstManeger.instance.foodC2 == "0"){
				timec2 -= Time.deltaTime;
				if(timec2 < 0){
					firstManeger.instance.enC2 += 1;
					enC2.text = ""+firstManeger.instance.enC2;
					enUp.instance.callFunc(2);
					timec2 = 180.0f;
				}
			}
			else{
				timeF2 -= Time.deltaTime;
				if(timeF2 < 0){
					firstManeger.instance.enC2 += 1;
					enC2.text = ""+firstManeger.instance.enC2;
					enUp.instance.callFunc(2);
					timeF2 = 120.0f;
				}
			}
		}
		if(firstManeger.instance.enC3 < firstManeger.instance.enFullC3){
			if(firstManeger.instance.foodC3 == "0"){
				timec3 -= Time.deltaTime;
				if(timec3 < 0){
					firstManeger.instance.enC3 += 1;
					enC3.text = ""+firstManeger.instance.enC3;
					enUp.instance.callFunc(3);
					timec3 = 180.0f;
				}
			}
			else{
				timeF3 -= Time.deltaTime;
				if(timeF3 < 0){
					firstManeger.instance.enC3 += 1;
					enC3.text = ""+firstManeger.instance.enC3;
					enUp.instance.callFunc(3);
					timeF3 = 120.0f;
				}
			}
		}




		if (firstManeger.instance.limit >= 1) {
			ec1.transform.localScale = new Vector3 ((float)firstManeger.instance.expC1/(float)firstManeger.instance.expFullC1 ,1.0f,1.0f);
			nc1.transform.localScale = new Vector3 ((float)firstManeger.instance.enC1/(float)firstManeger.instance.enFullC1 , 1.0f, 1.0f);

		}
		if(firstManeger.instance.limit >= 2){
			ec2.transform.localScale = new Vector3 ((float)firstManeger.instance.expC2/(float)firstManeger.instance.expFullC2 ,1.0f,1.0f);
			nc2.transform.localScale = new Vector3 ((float)firstManeger.instance.enC2/(float)firstManeger.instance.enFullC2, 1.0f, 1.0f);

		}
		if(firstManeger.instance.limit >= 3){
			ec3.transform.localScale = new Vector3 ((float)firstManeger.instance.expC3/(float)firstManeger.instance.expFullC3 ,1.0f,1.0f);
			nc3.transform.localScale = new Vector3 ((float)firstManeger.instance.enC3/(float)firstManeger.instance.enFullC3 , 1.0f, 1.0f);
		}
	}

	public void PlaySound(){
		GetComponent<AudioSource>().PlayOneShot (c);
		//print (c.name);
	}

	public void setScene(){

		Debug.Log ("(Main)state is " + firstManeger.instance.state);
		Debug.Log ("(Main)cat is "+ firstManeger.instance.count);
	
		if (firstManeger.instance.count == 0) {
			ChangeTexture.instance.change (firstManeger.instance.texcat1);
			if(firstManeger.instance.foodC1 == "1"){
				food.SetActive(true);
			}
			else{
				food.SetActive(false);
			}

			if(firstManeger.instance.ringC1 == "1"){
				ring.SetActive(true);
			}
			else{
				ring.SetActive(false);
			}

			cat1.gameObject.SetActive (true);	
		}
		else if(firstManeger.instance.count == 1){

			if(firstManeger.instance.limit-1 <  firstManeger.instance.count){
				ChangeTexture.instance.change (firstManeger.instance.texcat1);
				if(firstManeger.instance.foodC1 == "1"){
					food.SetActive(true);
				}
				else{
					food.SetActive(false);
				}

				if(firstManeger.instance.ringC1 == "1"){
					ring.SetActive(true);
				}
				else{
					ring.SetActive(false);
				}

				cat1.gameObject.SetActive (true);
			}
			else{
				ChangeTexture.instance.change (firstManeger.instance.texcat2);
				if(firstManeger.instance.foodC2 == "1"){
					food.SetActive(true);
				}
				else{
					food.SetActive(false);
				}

				if(firstManeger.instance.ringC2 == "1"){
					ring.SetActive(true);
				}
				else{
					ring.SetActive(false);
				}

				cat2.gameObject.SetActive (true);
			}

		}
		else if(firstManeger.instance.count == 2){
			if(firstManeger.instance.limit-1 <  firstManeger.instance.count){
				ChangeTexture.instance.change (firstManeger.instance.texcat1);
				if(firstManeger.instance.foodC1 == "1"){
					food.SetActive(true);
				}
				else{
					food.SetActive(false);
				}

				if(firstManeger.instance.ringC1 == "1"){
					ring.SetActive(true);
				}
				else{
					ring.SetActive(false);
				}
				cat1.gameObject.SetActive (true);
			}
			else{
				ChangeTexture.instance.change (firstManeger.instance.texcat3);
				if(firstManeger.instance.foodC3 == "1"){
					food.SetActive(true);
				}
				else{
					food.SetActive(false);
				}

				if(firstManeger.instance.ringC3 == "1"){
					ring.SetActive(true);
				}
				else{
					ring.SetActive(false);
				}
				cat3.gameObject.SetActive (true);
			}

		}



	}

}
