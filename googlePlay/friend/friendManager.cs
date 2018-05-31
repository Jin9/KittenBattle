using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;

public class friendManager : MonoBehaviour {

	public static friendManager instance;

	public bool isPopup = false;
	public bool haveFriend = false;
	public Canvas set;
	public Canvas expDe;
	public Canvas battle;
	public Canvas p;
	public Canvas load;
	public Canvas sub;

	public Text name;
	public Text degree;
	public Text money;

	int c = 0;

	private const float ERROR_STATUS_TIMEOUT = 10.0f; //second foe show error message
	private const float INFO_STATUS_TIMEOUT = 2.0f; //second foe show info message
	
	private float gStatusCountdown = 0.0f;

	public GameObject main;
	public GameObject chooseCat;

	public RawImage imWait;

	public GameObject show;
	public RawImage youwin;
	public RawImage youlose;
	public RawImage draw;

	public RawImage H_p1;
	public RawImage P_p1;
	public RawImage S_p1;
	public RawImage H_p2;
	public RawImage P_p2;
	public RawImage S_p2;


	public Text cName;
	public Text cLv;
	public Text cHp;
	public Text cAtk;
	public Text cDef;
	public Text cSpd;

	public string cTexture;

	public int myPlayer;
	
	public Text P1;
	public Text hp1;
	public Text lv1;
	public Text P2;
	public Text hp2;
	public Text lv2;

	float timeShow = 1.0f;
	public RawImage hpp1;
	public RawImage hpp2;

	public GameObject statusText; //text canvas
	private string StatusMsg = null;
	
	private bool processed = false;
	
	// Use this for initialization
	void Start () {

		Screen.orientation = ScreenOrientation.LandscapeLeft;
		instance = this;

		name.text = firstManeger.instance.name;
		degree.text = firstManeger.instance.level;
		money.text = ""+firstManeger.instance.money+"  .M";

		cName.text = "" + firstManeger.instance.nameC1;
		cLv.text = "" + firstManeger.instance.levelC1;
		cHp.text = "" + firstManeger.instance.hpC1;
		cAtk.text = "" + firstManeger.instance.atkC1;
		cDef.text = "" + firstManeger.instance.defC1;
		cSpd.text = "" + firstManeger.instance.spdC1;
		cTexture = "" + firstManeger.instance.texcat1;

		show.gameObject.SetActive (false);
		youwin.gameObject.SetActive (false);
		youlose.gameObject.SetActive (false);
		draw.gameObject.SetActive (false);
		H_p1.gameObject.SetActive (false);
		P_p1.gameObject.SetActive (false);
		S_p1.gameObject.SetActive (false);
		H_p2.gameObject.SetActive (false);
		P_p2.gameObject.SetActive (false);
		S_p2.gameObject.SetActive (false);


		imWait.gameObject.SetActive (false);
		sub.gameObject.SetActive (false);
		p.gameObject.SetActive (false);
		battle.gameObject.SetActive (false);
		chooseCat.SetActive (false);
		set.gameObject.SetActive (false);
		expDe.gameObject.SetActive (false);
		load.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		HanbleStatusUpdate ();
		
		// update invitation here
		
		if (GPGholder.Instance == null) {
			return;		
		}
		
		switch (GPGholder.Instance.State) {
		case GPGholder.gameState.SettingUp:
			if (statusText != null) {
				StatusMsg = null;
				showStatus ("Wait for a sec", false);
			}
			break;
		case GPGholder.gameState.SetupFailed:
			showStatus ("Game setup failed", true);
			GPGholder.Instance.CleanUp ();
			processed = false; 
			
			break;
		case GPGholder.gameState.Aborted:
			showStatus ("Game Aborted", true);
			GPGholder.Instance.CleanUp ();
			firstManeger.instance.state = 1;
			Application.LoadLevel("mainmenu");
			processed = false;
			break;
		case GPGholder.gameState.Finished:
			// show playing panel
			processed = false;
			break;
		case GPGholder.gameState.Playing:
			// show playing panel
			//main.SetActive(false);
			chooseCat.SetActive(true);
			isPopup = true;
			GameObject p_obj1 = GameObject.Find("Player1");
			GameObject p_obj2 = GameObject.Find("Player2");

			if(GPGholder.Instance.myPlayer == 0){
				P1.text = p_obj1.GetComponent<PlayerControl> ().Name;
				hp1.text = ""+p_obj1.GetComponent<PlayerControl>().mHp;
				lv1.text = "Level "+p_obj1.GetComponent<PlayerControl>().mLv;
				hpp1.transform.localScale = new Vector3 ((float)p_obj1.GetComponent<PlayerControl>().mHp/(float)p_obj1.GetComponent<PlayerControl>().HPFull ,1.0f,1.0f);
				ChangeTexture.instance.change(p_obj1.GetComponent<PlayerControl>().mTexture);

				P2.text = p_obj2.GetComponent<PlayerControl> ().Name;
				hp2.text = ""+p_obj2.GetComponent<PlayerControl>().mHp;
				lv2.text = "Level "+p_obj2.GetComponent<PlayerControl>().mLv;
				hpp2.transform.localScale = new Vector3 ((float)p_obj2.GetComponent<PlayerControl>().mHp/(float)p_obj2.GetComponent<PlayerControl>().HPFull ,1.0f,1.0f);
				NPChangeTex.instance.change(p_obj2.GetComponent<PlayerControl>().mTexture);
			}
			else{
				P1.text = p_obj2.GetComponent<PlayerControl> ().Name;
				hp1.text = ""+p_obj2.GetComponent<PlayerControl>().mHp;
				lv1.text = "Level "+p_obj2.GetComponent<PlayerControl>().mLv;
				hpp1.transform.localScale = new Vector3 ((float)p_obj2.GetComponent<PlayerControl>().mHp/(float)p_obj2.GetComponent<PlayerControl>().HPFull ,1.0f,1.0f);
				ChangeTexture.instance.change(p_obj2.GetComponent<PlayerControl>().mTexture);

				P2.text = p_obj1.GetComponent<PlayerControl> ().Name;
				hp2.text = ""+p_obj1.GetComponent<PlayerControl>().mHp;
				lv2.text = "Level "+p_obj1.GetComponent<PlayerControl>().mLv;
				hpp2.transform.localScale = new Vector3 ((float)p_obj1.GetComponent<PlayerControl>().mHp/(float)p_obj1.GetComponent<PlayerControl>().HPFull ,1.0f,1.0f);
				NPChangeTex.instance.change(p_obj1.GetComponent<PlayerControl>().mTexture);
			}

			//Application.LoadLevel("room");
			HandleGamePlay();
			//Debug.Log ("ooooJinoooo rState is : "+GPGholder.Instance.rState);
			switch(GPGholder.Instance.rState){
			case GPGholder.resultState.Win:
				//result.text = "You Win";
				//youwin.gameObject.SetActive(true);
				GPGholder.Instance.myChoose = 'X';
				animBattle.instance.isWin = true;
				imWait.gameObject.SetActive(false);
				friendManager.instance.youwin.gameObject.SetActive(true);
				friendManager.instance.youlose.gameObject.SetActive(false);
				friendManager.instance.draw.gameObject.SetActive(false);
				friendManager.instance.show.gameObject.SetActive(true);
				//GPGholder.Instance.animState();
				//GPGholder.Instance.setReState();
				break;
				
			case GPGholder.resultState.Draw:
				//result.text = "Draw";
				//draw.gameObject.SetActive(true);
				friendManager.instance.show.gameObject.SetActive(true);
				GPGholder.Instance.myChoose = 'X';
				//GPGholder.Instance.animState();
			
				friendManager.instance.youwin.gameObject.SetActive(false);
				friendManager.instance.youlose.gameObject.SetActive(false);
				friendManager.instance.draw.gameObject.SetActive(true);

				//friendManager.instance.battle.gameObject.SetActive(true);
				friendManager.instance.imWait.gameObject.SetActive(false);
	
				//GPGholder.Instance.setReState();


				break;
				
			case GPGholder.resultState.Lose:
				//result.text = "You Lose";
				//youlose.gameObject.SetActive(true);
				GPGholder.Instance.myChoose = 'X';
				//GPGholder.Instance.animState();
				imWait.gameObject.SetActive(false);
				friendManager.instance.youwin.gameObject.SetActive(false);
				friendManager.instance.youlose.gameObject.SetActive(true);
				friendManager.instance.draw.gameObject.SetActive(false);
				friendManager.instance.show.gameObject.SetActive(true);

				//GPGholder.Instance.setReState();
				break;
			default:
				break;
			}
			processed = false;
			break;
		default:
			break;
		}
		
		
	}
	
	void HandleGamePlay(){
		GPGholder.Instance.UpdateSelf ();
	}
	
	// show status text and clear when time out//
	void HanbleStatusUpdate(){
		if(statusText.activeSelf){
			gStatusCountdown -= Time.deltaTime;
			if(gStatusCountdown <= 0){
				statusText.SetActive(false);
			}
		}
		
	}
	
	void showStatus(string msg ,bool error){
		if( msg != StatusMsg){
			
			StatusMsg = msg;
			statusText.SetActive(true);
			Text tex = statusText.GetComponentInChildren<Text>(); //call text (child with panel)
			tex.text = msg;
			
			if(error){
				Color c = statusText.GetComponent<Image>().color;
				c.a = 1.0f;
				statusText.GetComponent<Image>().color = c;
				gStatusCountdown = ERROR_STATUS_TIMEOUT; //set time to show
			}
			else{
				Color c = statusText.GetComponent<Image>().color;
				c.a = 0.0f;
				statusText.GetComponent<Image>().color = c;
				gStatusCountdown = INFO_STATUS_TIMEOUT; //set time to show
			}
			
		}
		
	} 

	public void clickLeft(){

		int l = firstManeger.instance.limit;

		
		if (c == 0) {
			c = l - 1;
		}
		else{
			c--;
		}

		if (c == 0) {

			cName.text = "" + firstManeger.instance.nameC1;
			cLv.text = "" + firstManeger.instance.levelC1;
			cHp.text = "" + firstManeger.instance.hpC1;
			cAtk.text = "" + firstManeger.instance.atkC1;
			cDef.text = "" + firstManeger.instance.defC1;
			cSpd.text = "" + firstManeger.instance.spdC1;
			cTexture = ""+firstManeger.instance.texcat1;
		}
		else if(c == 1){
			cName.text = "" + firstManeger.instance.nameC2;
			cLv.text = "" + firstManeger.instance.levelC2;
			cHp.text = "" + firstManeger.instance.hpC2;
			cAtk.text = "" + firstManeger.instance.atkC2;
			cDef.text = "" + firstManeger.instance.defC2;
			cSpd.text = "" + firstManeger.instance.spdC2;
			cTexture = ""+firstManeger.instance.texcat2;
		}
		else if(c == 2){
			cName.text = "" + firstManeger.instance.nameC3;
			cLv.text = "" + firstManeger.instance.levelC3;
			cHp.text = "" + firstManeger.instance.hpC3;
			cAtk.text = "" + firstManeger.instance.atkC3;
			cDef.text = "" + firstManeger.instance.defC3;
			cSpd.text = "" + firstManeger.instance.spdC3;
			cTexture = ""+firstManeger.instance.texcat3;
		}
		//Debug.Log ("ooooJinoooo texture is from press ok "+cTexture);

	}

	public void clickRight(){

		int l = firstManeger.instance.limit;
		
		
		if (c == l - 1) {
			c = 0;
			
		} else {
			c ++;
		}
		
		if (c == 0) {
			
			cName.text = "" + firstManeger.instance.nameC1;
			cLv.text = "" + firstManeger.instance.levelC1;
			cHp.text = "" + firstManeger.instance.hpC1;
			cAtk.text = "" + firstManeger.instance.atkC1;
			cDef.text = "" + firstManeger.instance.defC1;
			cSpd.text = "" + firstManeger.instance.spdC1;
			cTexture = ""+firstManeger.instance.texcat1;
		}
		else if(c == 1){
			cName.text = "" + firstManeger.instance.nameC2;
			cLv.text = "" + firstManeger.instance.levelC2;
			cHp.text = "" + firstManeger.instance.hpC2;
			cAtk.text = "" + firstManeger.instance.atkC2;
			cDef.text = "" + firstManeger.instance.defC2;
			cSpd.text = "" + firstManeger.instance.spdC2;
			cTexture = ""+firstManeger.instance.texcat2;
		}
		else if(c == 2){
			cName.text = "" + firstManeger.instance.nameC3;
			cLv.text = "" + firstManeger.instance.levelC3;
			cHp.text = "" + firstManeger.instance.hpC3;
			cAtk.text = "" + firstManeger.instance.atkC3;
			cDef.text = "" + firstManeger.instance.defC3;
			cSpd.text = "" + firstManeger.instance.spdC3;
			cTexture = ""+firstManeger.instance.texcat3;
		}

		//Debug.Log ("ooooJinoooo texture is from press ok "+cTexture);
	}

	public void clickOK(){
		isPopup = false;
		main.SetActive (false);
		p.gameObject.SetActive (true);
		battle.gameObject.SetActive (true);



		string temp = cName.text + "-" + cLv.text + "-" + cHp.text + "-" + cDef.text + "-" + cAtk.text + "-" + cSpd.text + "-" + cTexture; 
		Debug.Log ("ooooJinoooo my texture "+cTexture);

		GameObject p_obj1 = GameObject.Find("Player1");
		GameObject p_obj2 = GameObject.Find("Player2");


		if (GPGholder.Instance.myPlayer == 0) {
			PlayerControl play = p_obj1.GetComponent<PlayerControl>();
			//ChangeTexture.instance.change (cTexture);
			play.setDataInfo(cName.text,int.Parse(cLv.text),int.Parse(cHp.text),int.Parse(cDef.text),int.Parse(cAtk.text),int.Parse(cSpd.text),cTexture);
		}
		else if(GPGholder.Instance.myPlayer == 1){
			PlayerControl play = p_obj2.GetComponent<PlayerControl>();
			//NPChangeTex.instance.change (cTexture);
			play.setDataInfo(cName.text,int.Parse(cLv.text),int.Parse(cHp.text),int.Parse(cDef.text),int.Parse(cAtk.text),int.Parse(cSpd.text),cTexture);
		}
		if(haveFriend == false){
			load.gameObject.SetActive (true);
		}

		GPGholder.Instance.SendInfo (temp);
	}

	// press invite button 
	public void OnInvite(){
		
		GPGholder.CreateWithInvitationScreen ();
	}
	
	// press inbox button to check friend request
	public void OnInboxClick(){
		
		if(processed){
			return;
		}
		
		processed = true;
		GPGholder.AcceptFromInbox ();
	}

	public void OnInviteClick(){
		if (FB.IsLoggedIn) {
			FB.AppRequest (
				message : "This game is awesome, join me now.",
				title : "Invite your friend to join you."
			);		
		}
	}
}
