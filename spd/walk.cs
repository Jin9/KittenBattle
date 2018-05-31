using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {

	public static walk instace;
	public GameObject cat;
	public GameObject sket;
	public bool issit = false;
	public bool setCam = false;
	public Animator anim;
	float dist = -13.52f;
	float distSket = -93.79f;
	float t = 3.0f;

	// Use this for initialization
	void Start () {

		instace = this;
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim) {
			t -= Time.deltaTime;

			if(t < 1.0f && t > 0.52f){
				issit = true;
				anim.SetTrigger("sit");

			}
			else if(t < -1.0f && t > -8.0f){
				distSket += 0.08f;
				sket.transform.localPosition = new Vector3(4.6f,6.88f,distSket);
			}
			else if(t < -8.0f){
				Application.LoadLevel("spdGame");
			}
			else if(t<0){
				cat.transform.localPosition = new Vector3 (0.0f,0.2678f,-0.017f);

			}
			else{
				if(issit == true){
					setCam = true;
				}
				dist += 0.06f;	
				cat.transform.localPosition = new Vector3 (0.0f,-0.67f,dist);
			}
		}


	}
}
