using UnityEngine;
using System.Collections;

public class foodOk : MonoBehaviour {

	public void clickOk(){
		payMoney.instance.callFunc (500,1);
		Application.LoadLevel ("loadScreen");
	}

}
