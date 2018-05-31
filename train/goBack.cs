using UnityEngine;
using System.Collections;

public class goBack : MonoBehaviour {

	public void click(){

		if (firstManeger.instance.state == 2) {
			if(trainManeger.instance.ispopup == false){
				firstManeger.instance.state = 1;
				Application.LoadLevel ("mainmenu");
			}	
		}
		if(firstManeger.instance.state == 10){
			if(shopManager.instance.ispopup == false){
				firstManeger.instance.state = 1;
				Application.LoadLevel ("mainmenu");
			}	

		}
		if(firstManeger.instance.state == 12){
			if(rankManager.instance.ispopUp == false){
				firstManeger.instance.state = 1;
				Application.LoadLevel ("mainmenu");
			}	

		}
		if(firstManeger.instance.state == 13){
			if(friendManager.instance.isPopup == false){
				firstManeger.instance.state = 1;
				Application.LoadLevel ("mainmenu");
			}
		}


	}
}
