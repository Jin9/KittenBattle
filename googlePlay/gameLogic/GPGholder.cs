using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using System.Collections.Generic;
//using System;

public class GPGholder : RealTimeMultiplayerListener {
	string[] PlayName = new string[] {"Player1","Player2"};
	const int QuickGameOpponents = 1;
	const int GameVariant = 0;
	const int MinOpponents = 1;
	const int MaxOpponents = 1;
	static GPGholder ginstance = null;
	public int stateWait = 0;
	public enum gameState { SettingUp, Playing, Finished, SetupFailed, Aborted ,Waiting};

	public int myPlayer;
	public string rankState = "";

	public enum resultState { Win , Lose ,Draw , Wait , WinWait , WaitAnim};
	private gameState gState = gameState.SettingUp;
	private resultState reState = resultState.Wait;
	
	private string gMyParticipantId = "";
	
	public char myChoose = 'X';
	
	private float progress = 0.0f;
	
	const float FakeProgressSpeed = 1.0f;
	const float MaxFakeProgress = 30.0f;
	float mRoomSetupStartTime = 0.0f;
	
	
	public gameState State{
		
		get{
			return gState;
		}
	}
	
	public void setReState(){
		reState = resultState.Wait;
	}

	public void animState(){
		reState = resultState.WaitAnim;
	}
	
	public resultState rState{
		
		get{
			return reState;
		}
	}
	
	public static GPGholder Instance{
		get{
			return ginstance;
		}
	}
	
	public static void CreateWithInvitationScreen() {
		ginstance = new GPGholder();
		Debug.Log ("ooooJinoooo  in createWithInvitationScreen");
		PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen(MinOpponents, MaxOpponents,
		                                                               GameVariant, ginstance);
	}
	
	public static void AcceptFromInbox() {
		ginstance = new GPGholder();
		Debug.Log ("ooooJinoooo  in AcceptFormInbox");
		PlayGamesPlatform.Instance.RealTime.AcceptFromInbox(ginstance);
	}
	
	public static void AcceptInvitation(string invitationId) {
		ginstance = new GPGholder();
		Debug.Log ("ooooJinoooo  in AcceptInvitation");
		PlayGamesPlatform.Instance.RealTime.AcceptInvitation(invitationId, ginstance);
	}
	
	public float RoomSetupProgress {
		get {
			float fakeProgress = (Time.time - mRoomSetupStartTime) * FakeProgressSpeed;
			if (fakeProgress > MaxFakeProgress) {
				fakeProgress = MaxFakeProgress;
			}
			float prog = progress + fakeProgress;
			return prog < 99.0f ? prog : 99.0f;
		}
	}
	
	public void OnRoomSetupProgress(float percent) {
		Debug.Log ("ooooJinoooo  in OnRoomSetupProgress");
		Debug.Log ("ooooJinoooo progress is "+progress);
		progress = percent;
	}
	
	public void OnRoomConnected(bool success) {
		if (success) {
			gState = gameState.Playing;
			//gState = gameState.Waiting;
			gMyParticipantId = GetSelf().ParticipantId;
			Debug.Log ("ooooJinoooo  in RoomConnect");
			Debug.Log ("ooooJinoooo my Partisipant id is" + gMyParticipantId);
			//Application.LoadLevel("room");
			SetupTrack();
		} 
		else {
			gState = gameState.SetupFailed;
		}
	}
	
	private void SetupTrack(){
		
		Debug.Log ("ooooJinoooo  About to get self");
		Participant self = GetSelf ();
		Debug.Log ("ooooJinoooo Self is " + self);
		Debug.Log ("ooooJinoooo About to get a list of connected participants");
		// list of partisipant id
		List<Participant> players = GetPlayers();
		Debug.Log ("ooooJinoooo Racers is  " + players + " with count of " + players.Count);
		
		int i;
		for(i = 0 ; i < PlayName.Length ;i++){
			Debug.Log("ooooJinoooo Looking at i value of " + i);
			GameObject play = GameObject.Find(PlayName[i]);
			Debug.Log ("ooooJinoooo Looking for play name " + PlayName[i]);
			Debug.Log ("ooooJinoooo Looking for play obj " + play);
			Participant player = i < players.Count ? players[i] : null;
			Debug.Log ("ooooJinoooo Racer is " + player);
			
			bool isSelf = player != null && player.ParticipantId.Equals(self.ParticipantId);
			if (player != null){
				Debug.Log ("ooooJinoooo player is not missing.");
				PlayerControl p = play.GetComponent<PlayerControl>();
				p.SetParticipantId(player.ParticipantId);
				p.SetBlinking(isSelf);
				if(isSelf){
					myPlayer = i;
					Debug.Log("ooooJinoooo myPlayer is " + i);
				}
			}
			else{
				Debug.Log ("ooooJinoooo player is missing.");
			}
		}
		
		
		
	}
	
	public void OnLeftRoom() {
		
		if(gState != gameState.Finished){
			
			gState = gameState.Aborted;
		}
	}
	
	public void OnPeersConnected(string[] peers) {

	}
	
	public void OnPeersDisconnected(string[] peers) {
		// if, as a result, we are the only player in the race, it's over
		List<Participant> players = GetPlayers();
		if (gState == gameState.Playing && (players == null || players.Count < 2)) {
			gState = gameState.Aborted;
		}	
	}
	
	public void UpdateSelf(){
		if (myChoose != 'X') {
			if(stateWait == 0){
				stateWait = 1;
				BroadCast(myChoose);
			}
			
		}
		
	}
	
	//byte[] result = new byte[1];
	public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data){

		char state = (char)data [0];
		if (state == 'c') {
			
			/* case press h,s,p */
			char temp = (char)data [1];
			char fPress = (char)data [2];
			char mPress = 'f';

			//Debug.Log ("ooooJinoooo choose : " + temp); // temp is character type

			for (int i =0; i < PlayName.Length; i++) {
				GameObject play = GameObject.Find (PlayName [i]);
				PlayerControl p = play.GetComponent<PlayerControl> ();
				if (!p.Blink) {
						//p.setTurn();
						p.setPress (fPress);
				} else {
						mPress = p.mPrees;
				}
			}

			if (mPress == fPress) {
				if (temp == myChoose) {
					/* draw case*/

					friendManager.instance.draw.gameObject.SetActive(true);
					if(temp == 'H'){
						friendManager.instance.H_p2.gameObject.SetActive(true);
						friendManager.instance.H_p1.gameObject.SetActive(true);
						friendManager.instance.S_p2.gameObject.SetActive(false);
						friendManager.instance.S_p1.gameObject.SetActive(false);
						friendManager.instance.P_p2.gameObject.SetActive(false);
						friendManager.instance.P_p1.gameObject.SetActive(false);
					}
					else if(temp == 'P'){
						friendManager.instance.P_p2.gameObject.SetActive(true);
						friendManager.instance.P_p1.gameObject.SetActive(true);
						friendManager.instance.H_p2.gameObject.SetActive(false);
						friendManager.instance.H_p1.gameObject.SetActive(false);
						friendManager.instance.S_p2.gameObject.SetActive(false);
						friendManager.instance.S_p1.gameObject.SetActive(false);
					}
					else if(temp == 'S'){
						friendManager.instance.S_p2.gameObject.SetActive(true);
						friendManager.instance.S_p1.gameObject.SetActive(true);
						friendManager.instance.H_p2.gameObject.SetActive(false);
						friendManager.instance.H_p1.gameObject.SetActive(false);
						friendManager.instance.P_p2.gameObject.SetActive(false);
						friendManager.instance.P_p1.gameObject.SetActive(false);
					}
					reState = resultState.Draw;
				} 
				else {
					reState = resultState.WinWait;

					float atk;
					float ang = 0.0f;
					float def;
					float att;

					float op;
					float spdA;
					float spdB;

					int ran;
					char m;
					GameObject p_obj1 = GameObject.Find ("Player1");
					GameObject p_obj2 = GameObject.Find ("Player2");

					if (myPlayer == 0) {
						PlayerControl p1 = p_obj1.GetComponent<PlayerControl> ();
						atk = p1.mAtk;
						PlayerControl p2 = p_obj2.GetComponent<PlayerControl> ();
						def = p2.mDef;

						att = (atk + (atk * 10.0f / 100.0f) * (ang / 3.0f)) - def;
						if (att <= 0.0f) {
								att = 1.0f;
						}

						spdA = p1.mSpd;
						spdB = p2.mSpd;
						
						if(spdA > spdB){
							ran = Random.Range (1, 100);
							if (ran > 15){ m = 'N';}
							else{ m = 'M';}
						}
						else {
							ran = Random.Range (1, 100);
							if (ran > 40){ m = 'N';}
							else{ m = 'M';}
						}

					}
					else{
						PlayerControl p1 = p_obj2.GetComponent<PlayerControl> ();
						atk = p1.mAtk;
						PlayerControl p2 = p_obj1.GetComponent<PlayerControl> ();
						def = p2.mDef;
						
						att = (atk + (atk * 10.0f / 100.0f) * (ang / 3.0f)) - def;
						if (att <= 0.0f) {
							att = 1.0f;
						}
						
						spdA = p1.mSpd;
						spdB = p2.mSpd;

						if(spdA > spdB){
							ran = Random.Range (1, 100);
							if (ran > 15){ m = 'N';}
							else{ m = 'M';}
						}
						else {
							ran = Random.Range (1, 100);
							if (ran > 40){ m = 'N';}
							else{ m = 'M';}
						}
					
					}
				
				
					if (temp == 'H' && myChoose == 'P') {
						//reState = resultState.Win;
						friendManager.instance.H_p2.gameObject.SetActive(true);
						friendManager.instance.P_p1.gameObject.SetActive(true);

						friendManager.instance.P_p2.gameObject.SetActive(false);
						friendManager.instance.H_p1.gameObject.SetActive(false);
						friendManager.instance.S_p2.gameObject.SetActive(false);
						friendManager.instance.S_p1.gameObject.SetActive(false);

						SendResult (m,Mathf.FloorToInt(att));
					}
					if (temp == 'H' && myChoose == 'S') {

						friendManager.instance.H_p2.gameObject.SetActive(true);
						friendManager.instance.S_p1.gameObject.SetActive(true);

						friendManager.instance.S_p2.gameObject.SetActive(false);
						friendManager.instance.H_p1.gameObject.SetActive(false);
						friendManager.instance.P_p2.gameObject.SetActive(false);
						friendManager.instance.P_p1.gameObject.SetActive(false);
						//reState = resultState.Lose;
					}
					if (temp == 'P' && myChoose == 'H') {
						//reState = resultState.Lose;
						friendManager.instance.P_p2.gameObject.SetActive(true);
						friendManager.instance.H_p1.gameObject.SetActive(true);

						friendManager.instance.H_p2.gameObject.SetActive(false);
						friendManager.instance.P_p1.gameObject.SetActive(false);
						friendManager.instance.S_p2.gameObject.SetActive(false);
						friendManager.instance.S_p1.gameObject.SetActive(false);
					}
					if (temp == 'P' && myChoose == 'S') {
						//reState = resultState.Win;friendManager.instance.H_p2.gameObject.SetActive(true);
						friendManager.instance.P_p2.gameObject.SetActive(true);
						friendManager.instance.S_p1.gameObject.SetActive(true);

						friendManager.instance.P_p1.gameObject.SetActive(false);
						friendManager.instance.S_p2.gameObject.SetActive(false);
						friendManager.instance.H_p1.gameObject.SetActive(false);
						friendManager.instance.H_p2.gameObject.SetActive(false);

						SendResult (m,Mathf.FloorToInt(att));
					}
					if (temp == 'S' && myChoose == 'H') {
						//reState = resultState.Win;
						friendManager.instance.S_p2.gameObject.SetActive(true);
						friendManager.instance.H_p1.gameObject.SetActive(true);

						friendManager.instance.S_p1.gameObject.SetActive(false);
						friendManager.instance.H_p2.gameObject.SetActive(false);
						friendManager.instance.P_p1.gameObject.SetActive(false);
						friendManager.instance.P_p2.gameObject.SetActive(false);

						SendResult (m,Mathf.FloorToInt(att));
					}
					if (temp == 'S' && myChoose == 'P') {
						friendManager.instance.S_p2.gameObject.SetActive(true);
						friendManager.instance.P_p1.gameObject.SetActive(true);

						friendManager.instance.S_p1.gameObject.SetActive(false);
						friendManager.instance.P_p2.gameObject.SetActive(false);
						friendManager.instance.H_p1.gameObject.SetActive(false);
						friendManager.instance.H_p2.gameObject.SetActive(false);
						//reState = resultState.Lose;
					}
				}

				stateWait = 0;
				for (int i =0; i < PlayName.Length; i++) {
					GameObject play = GameObject.Find (PlayName [i]);
					PlayerControl p = play.GetComponent<PlayerControl> ();
					p.setPress ('f');
				}
		
			}
		} 
		else if (state == 'i') {
			/* case send data */
			friendManager.instance.haveFriend = true;
			friendManager.instance.load.gameObject.SetActive (false);
			char[] chars = new char[data.Length / sizeof(char)];
			System.Buffer.BlockCopy (data, 0, chars, 0, data.Length);
			//return new string (chars);
			string temp = new string (chars);
			//Debug.Log ("ooooJinoooo temp is " + temp);
			string[] tempArray = temp.Split ('-');

			Participant self = GetSelf ();
			List<Participant> players = GetPlayers ();


			int i;
			for (i = 0; i < PlayName.Length; i++) {

				GameObject play = GameObject.Find (PlayName [i]);
				PlayerControl p = play.GetComponent<PlayerControl> ();
				//Debug.Log ("ooooJinoooo show id : " + p.ParticipantId);
				if (p.ParticipantId == senderId) {
					p.setDataInfo (tempArray [1], int.Parse (tempArray [2]), int.Parse (tempArray [3]),
	              	int.Parse (tempArray [4]), int.Parse (tempArray [5]), int.Parse (tempArray [6]), tempArray [7]); // store data in my controler

					//NPChangeTex.instance.change(tempArray[7]);
					Debug.Log("ooooJinoooo friend Texture is "+tempArray[7]);
				}
				Debug.Log ("ooooJinoooo Texture : "+p.mTexture+" and i is "+i);
			
			}



		} 
		else if (state == 'r') {
			char s = (char)data[1];
			int a = (int)data[2];

			if(s == 'M'){
				reState = resultState.Lose;
				animBattle.instance.isMiss = 0;
				animBattle.instance.isLose = true;
			}
			else {
				/* have to minus hp */
				reState = resultState.Lose;
				animBattle.instance.isMiss = 1;
				animBattle.instance.isLose = true;
				GameObject p_obj1 = GameObject.Find("Player1");
				GameObject p_obj2 = GameObject.Find("Player2");

				if(myPlayer == 0){
					PlayerControl p1 = p_obj1.GetComponent<PlayerControl> ();
					p1.mHp = p1.mHp - a;
					if(p1.mHp <= 0){
						p1.mHp = 0;
						rankState = "Lose";
					}
				}
				else{
					PlayerControl p1 = p_obj2.GetComponent<PlayerControl> ();
					p1.mHp = p1.mHp - a;
					if(p1.mHp <= 0){
						p1.mHp = 0;
						rankState = "Lose";
					}
				}

			}
		}
	}

	public void SendResult(char miss, int att){


		//miss = M //attack = N
		if (miss == 'M') {
				reState = resultState.Win;
				animBattle.instance.isMiss = 0;
		} else {
				reState = resultState.Win;
				animBattle.instance.isMiss = 1;
				GameObject p_obj1 = GameObject.Find ("Player1");
				GameObject p_obj2 = GameObject.Find ("Player2");

				if (myPlayer == 0) {
						PlayerControl p1 = p_obj2.GetComponent<PlayerControl> ();
						p1.mHp = p1.mHp - att;
						if (p1.mHp <= 0) {
								p1.mHp = 0;
								rankState = "Win";
						}
				} else {
						PlayerControl p1 = p_obj1.GetComponent<PlayerControl> ();
						p1.mHp = p1.mHp - att;
						if (p1.mHp <= 0) {
								p1.mHp = 0;
								rankState = "Win";
						}
				}
		}

		byte[] packet = new byte[3];
		packet [0] = (byte)'r';
		packet [1] = (byte)miss;
		packet [2] = (byte)att;

		PlayGamesPlatform.Instance.RealTime.SendMessageToAll (true, packet); 

	}
	
	public void SendInfo(string data){
		//Debug.Log ("ooooJinoooo in sendInfo : "+data);
		string temp = "i-"+data;
		//Debug.Log ("ooooJinoooo in sendInfo add type : "+temp);
		byte[] bytes = new byte[temp.Length * sizeof(char)];
		System.Buffer.BlockCopy (temp.ToCharArray(),0,bytes,0,bytes.Length);
		PlayGamesPlatform.Instance.RealTime.SendMessageToAll (true, bytes);
	}
	
	public void BroadCast(char c){
		byte[] packet = new byte[3];
		packet[0] = (byte)'c';
		Debug.Log ("ooooJinoooo value : "+myChoose);
		packet[1] = (byte)c;
		for (int i =0 ; i < PlayName.Length ; i++) {
			GameObject play = GameObject.Find(PlayName[i]);
			PlayerControl p = play.GetComponent<PlayerControl>();
			if(p.Blink){
				p.setPress('t');
				//p.setTurn();
				packet[2] = (byte)p.mPrees;
			}
		}
		PlayGamesPlatform.Instance.RealTime.SendMessageToAll (true, packet);
	}
	
	
	private Participant GetSelf() {
		return PlayGamesPlatform.Instance.RealTime.GetSelf();
	}
	
	private List<Participant> GetPlayers() {
		return PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants();
	}
	
	public void CleanUp() {
		PlayGamesPlatform.Instance.RealTime.LeaveRoom();
		//TearDownTrack(); /* set play scene is not visible */
		rankState = "";
		gState = gameState.Aborted;
		ginstance = null;
	}

	public void FinishedMacth(){
		gState = gameState.Finished;
		//gMyParticipantId
		if (rankState.Equals ("Win")) {
			firstManeger.instance.battle = 1;
			Debug.Log ("ooooJinoooo You win");
			//friendManager.instance.youwin.gameObject.SetActive(true);

			CleanUp();
			Application.LoadLevel("loadScreen");
		}
		else {
			Debug.Log ("ooooJinoooo You lose");
			firstManeger.instance.battle = 0;
			//friendManager.instance.youlose.gameObject.SetActive(true);
			CleanUp();
			Application.LoadLevel("loadScreen");
		}
	}
}
