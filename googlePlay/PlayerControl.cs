using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public static PlayerControl instance;
	private bool mBlink = false;
	private string mParticipantId = null;
	public string mName;
	public int mLv;
	public int mHp;
	public int HPFull;
	public int mDef;
	public int mAtk;
	public int mSpd;
	public string mTexture;

	public int mTurn = 0;
	public char mPrees = 'f';
	
	// Use this for initialization
	void Start () {
		
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {


	}
	
	public void setPress(char c){
		mPrees = c;
	}
	
	public void setTurn(){
		mTurn += 1;
	}
	
	public void SetParticipantId(string id) {
		mParticipantId = id;
	}
	
	public void SetBlinking(bool blink) {
		mBlink = blink;
	}
	
	
	public void setDataInfo(string name,int lv,int hp,int def, int atk, int spd, string texture){
		mName = name;
		mLv = lv;
		mHp = hp;
		HPFull = hp;
		mDef = def;
		mAtk = atk;
		mSpd = spd;
		mTexture = texture;
	}
	
	
	public string ParticipantId {
		get {
			return mParticipantId;
		}
	}
	
	public bool Blink{
		get {
			return mBlink;
		}
	}
	
	public string Name{
		get {
			return mName;
		}
	}
	
	public char Status{
		get{
			return mPrees;
		}
	}
	
	
	public void Reset() {
		mParticipantId = null;
		mBlink = false;
	}
}
