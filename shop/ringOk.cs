using UnityEngine;
using System.Collections;

public class ringOk : MonoBehaviour {

	public void clickOk(){
		payMoney.instance.callFunc (200,2);
		Application.LoadLevel ("loadScreen");
	}
}
