using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scratch : MonoBehaviour {

	public GameObject sc;
	public GameObject mainCanvas;

	int c = 0;
	public GameObject currentscratch;
	public Vector3 startposition;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (AtkGameManager.instance.isPause == false && AtkGameManager.instance.isready == true ) {
			if(Input.GetButtonDown("Fire1")){

				//print ("down");
				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				GameObject s = Instantiate(sc) as GameObject;
				currentscratch = s;
				s.transform.SetParent( mainCanvas.transform );
				s.transform.position = ray.GetPoint( 0.85f );
				startposition = ray.GetPoint(0.85f);
				s.transform.localPosition = new Vector3( s.transform.localPosition.x 
				                                        , s.transform.localPosition.y , 0 );
				s.transform.localScale = Vector3.one;
				s.transform.localScale = new Vector3( 1 , 0 , 1 );
				//print(startposition);
			}
			if(Input.GetButton("Fire1"))
			{
				//print("stay");

				Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
				float difx = ray.GetPoint( 0.85f ).x - startposition.x;
				float dify = ray.GetPoint( 0.85f ).y - startposition.y;
				float powx = Mathf.Pow(difx,2);
				float powy = Mathf.Pow(dify,2);
				float dist = Mathf.Sqrt(powx+powy);

				//Debug.Log(dist);

				if(dist > 0.005){
					c = 1;

				}

				currentscratch.transform.localScale = new Vector3(1,dist*430,1);
				
				float angle = ( Mathf.Atan2(dify, difx)* 180 )/Mathf.PI;
				
				currentscratch.transform.localEulerAngles = new Vector3( 0 , 0 , angle+90 );
			}
			
			if (Input.GetButtonUp ("Fire1")) 
			{
				if( setScore.instance.count == 1 && c == 1 ){
					//count = 1;
					AtkGameManager.instance.playSound();
					PlayerAtk.instance.scoreUpdate (5);
					AtkGameManager.instance.setThemo();
				}
				//print("up");
				setScore.instance.count = 0;
				c = 0;

				StartCoroutine( fadeScratch( currentscratch ) );
			}
		}

	}

	IEnumerator fadeScratch(GameObject scr){

		float timer = 0;
		RawImage a = scr.GetComponent<RawImage> ();
		Color startcolor = a.color;

		//int timeInt = Mathf.Round ( timer );

		while (timer < 1) {
			timer += Time.deltaTime;
			startcolor = new Color(startcolor.r,startcolor.g,startcolor.b, Mathf.Lerp( 1.0f , 0.0f , timer ) );

			a.color = startcolor;

			yield return null;
		}

		Destroy (scr);
	}



}
