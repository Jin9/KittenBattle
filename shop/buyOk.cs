using UnityEngine;
using System.Collections;

public class buyOk : MonoBehaviour {

	public void clickOk(){
		firstManeger.instance.state = 11;
		payMoney.instance.callFunc (1000,0);
		Application.LoadLevel ("box");
	}


}
