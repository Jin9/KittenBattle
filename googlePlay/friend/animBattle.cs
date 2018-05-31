using UnityEngine;
using System.Collections;

public class animBattle : MonoBehaviour {

	public static animBattle instance;
	public GameObject catP1;
	public GameObject catP2;

	public Animator animP1;
	public Animator animP2;

	float time = 2.15f;
	float posxP1 = -16.8f;
	float poszP1 = 43.5f;

	float posxP2 = 22.3f;
	float poszP2 = 96.1f;

	public bool isWin = false;
	public bool isLose = false;

	public int isMiss; //0 = miss 1= atk

	// Use this for initialization
	void Start () {
	
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(animP1){

				animP1.SetTrigger("isIdle");
				animP2.SetTrigger("isIdle");

				//Debug.Log ("ooooJinoooo in update time is "+time);

			switch(GPGholder.Instance.rState){

			case GPGholder.resultState.WaitAnim:

				//Debug.Log("ooooJinoooo in waitAnim");
				//Debug.Log("ooooJinoooo iswin = "+isWin);
				if(isWin == true){

					Debug.Log("ooooJinoooo iswin = true");

					time -= Time.deltaTime;
					
					//animP1.SetTrigger("isRun");
					
					if(time > 0.25f){
						
						//Debug.Log ("ooooJinoooo in isWin case 1 (time > 0.16) time is "+time);
						animP1.SetTrigger("isRun");
						posxP1 += 0.219f;
						poszP1 += 0.314f;
						catP1.transform.localPosition = new Vector3 (posxP1,42.8f,poszP1);
						
						
					}
					else if (time > 0.0f){
						
						//Debug.Log ("ooooJinoooo in isWin case 1 (time > 0.0) time is "+time);
						animP1.SetTrigger("isPunch");
						if(isMiss == 0){
							animP2.SetTrigger("isMiss");
						}
						else{
							animP2.SetTrigger("isHurt");
						}
						animP1.SetTrigger("isIdle");
						animP2.SetTrigger("isIdle");
						
						
						
					}
					else if(time > -0.1f){
						animP1.SetTrigger("isIdle");
						//Debug.Log ("ooooJinoooo in isWin case 1 (time > -0.1) time is "+time);
						isWin = false;
						isLose = false;
						posxP1 = -16.8f;
						poszP1 = 43.5f;
						
						catP1.transform.localPosition = new Vector3(posxP1,42.8f,poszP1);
						//animP1.SetTrigger("isIdle");
						time = 2.16f;
						friendManager.instance.battle.gameObject.SetActive(true);
						friendManager.instance.imWait.gameObject.SetActive(false);
						//friendManager.instance.show.gameObject.SetActive(false);
						GPGholder.Instance.setReState();
					}
					
				}
				else{
					friendManager.instance.battle.gameObject.SetActive(true);
					friendManager.instance.imWait.gameObject.SetActive(false);
					//friendManager.instance.show.gameObject.SetActive(false);
					GPGholder.Instance.setReState();
				}

				if(isLose == true){
					time -= Time.deltaTime;
					//animP2.SetTrigger("isRun");
					
					if(time > 0.16f){
						animP2.SetTrigger("isRun");
						posxP2 -= 0.219f;
						poszP2 -= 0.314f;
						catP2.transform.localPosition = new Vector3 (posxP2,42.8f,poszP2);
						
						
					}
					else if (time > 0.0f){
						animP2.SetTrigger("isPunch");
						if(isMiss == 0){
							animP1.SetTrigger("isMiss");
						}
						else{
							animP1.SetTrigger("isHurt");
						}
						animP1.SetTrigger("isIdle");
						animP2.SetTrigger("isIdle");
					}
					else if(time > -0.1f){
						
						
						isWin = false;
						isLose = false;
						
						posxP2 = 22.3f;
						poszP2 = 96.1f;
						
						
						
						catP2.transform.localPosition = new Vector3(posxP2,42.8f,poszP2);
						animP2.SetTrigger("isIdle");
						time = 2.16f;
						friendManager.instance.battle.gameObject.SetActive(true);
						friendManager.instance.imWait.gameObject.SetActive(false);
						//friendManager.instance.show.gameObject.SetActive(false);
						GPGholder.Instance.setReState();
					}
					
					
				}
				else{
					friendManager.instance.battle.gameObject.SetActive(true);
					friendManager.instance.imWait.gameObject.SetActive(false);
					//friendManager.instance.show.gameObject.SetActive(false);
					GPGholder.Instance.setReState();
				}

				if(GPGholder.Instance.rankState.Length != 0){
					GPGholder.Instance.FinishedMacth();
				}

				break;

			default:

				break;

		}		
	}
}
}
