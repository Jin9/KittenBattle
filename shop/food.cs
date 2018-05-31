using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class food : MonoBehaviour {

	public Canvas cantBuy;
	public Canvas foodCan;
	public Canvas maxFood;

	public Text name;
	public Text level;


	public void clickBuyFood(){

		if (shopManager.instance.ispopup == false) {
				
			if (firstManeger.instance.money < 500) {
				cantBuy.gameObject.SetActive(true);
				shopManager.instance.ispopup = true;
			}
			else{

				if(firstManeger.instance.foodC1 == "1" && firstManeger.instance.foodC2 == "1" && firstManeger.instance.foodC3 == "1"){
					//have all
					maxFood.gameObject.SetActive(true);

				}
				else{

					foodCan.gameObject.SetActive(true);
					if(firstManeger.instance.foodC1 == "0"){
	
						shopManager.instance.limit++;
						shopManager.instance.n1 = firstManeger.instance.nameC1;
						shopManager.instance.l1 = firstManeger.instance.levelC1;
						shopManager.instance.id1 = firstManeger.instance.catid1;
					}
					if(firstManeger.instance.foodC2 == "0"){
					
						shopManager.instance.limit++;
						if(shopManager.instance.limit == 1){
							shopManager.instance.n1 = firstManeger.instance.nameC2;
							shopManager.instance.l1 = firstManeger.instance.levelC2;
							shopManager.instance.id1 = firstManeger.instance.catid2;
						}
						else{
							shopManager.instance.n2 = firstManeger.instance.nameC2;
							shopManager.instance.l2 = firstManeger.instance.levelC2;
							shopManager.instance.id2 = firstManeger.instance.catid2;
						}
						
						
					}
					if(firstManeger.instance.foodC3 == "0"){
					
						shopManager.instance.limit++;
						if(shopManager.instance.limit == 1){
							shopManager.instance.n1 = firstManeger.instance.nameC3;
							shopManager.instance.l1 = firstManeger.instance.levelC3;
							shopManager.instance.id1 = firstManeger.instance.catid3;
						}
						else if(shopManager.instance.limit == 2){
							shopManager.instance.n2 = firstManeger.instance.nameC3;
							shopManager.instance.l2 = firstManeger.instance.levelC3;
							shopManager.instance.id2 = firstManeger.instance.catid3;
						}
						else{
							shopManager.instance.n3 = firstManeger.instance.nameC3;
							shopManager.instance.l3 = firstManeger.instance.levelC3;
							shopManager.instance.id3 = firstManeger.instance.catid3;
						}
						
					}


					if(firstManeger.instance.foodC1 == "0"){
						name.text = firstManeger.instance.nameC1;
						level.text = ""+firstManeger.instance.levelC1;
						//shopManager.instance.choose = 0;
					}
					else if(firstManeger.instance.foodC2 == "0"){
						name.text = firstManeger.instance.nameC2;
						level.text = ""+firstManeger.instance.levelC2;
						///shopManager.instance.choose = 0;

					}
					else if(firstManeger.instance.foodC3 == "0"){
						name.text = firstManeger.instance.nameC3;
						level.text = ""+firstManeger.instance.levelC3;
						//shopManager.instance.choose = 0;
					}
					
					shopManager.instance.ispopup = true;
				}

			}
		}

	}
}
