using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public Transform[] PatrolPoint;
	public float moveSpeed;
	private int currentPoint;

	public GameObject raw1;
	public GameObject raw2;
	public GameObject raw3;

	void Awake(){
		raw1 = GameObject.Find ("RawImage1");
		raw2 = GameObject.Find ("RawImage2");
		raw3 = GameObject.Find ("RawImage3");
	}

	// Use this for initialization
	void Start () {
		transform.position = PatrolPoint [0].position;
		currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
	

		if(transform.position == PatrolPoint[currentPoint].position)
		{
			currentPoint++;

		}

		if (currentPoint >= PatrolPoint.Length)
		{

			currentPoint = 0;

			PlayerDef.instance.miss ++;
			PlayerDef.instance.combo = 0;
			setcombo.instance.showMiss();
			GameManager.instance.PlayMiss();

			if(PlayerDef.instance.miss == 1){
				raw1.GetComponent<RawImage>().color = new Color (1,1,1,1);
			}
			if(PlayerDef.instance.miss == 2){
				raw2.GetComponent<RawImage>().color = new Color (1,1,1,1);
			}
			if(PlayerDef.instance.miss == 3){
				raw3.GetComponent<RawImage>().color = new Color (1,1,1,1);
			}
			if(PlayerDef.instance.miss == 4){
				//SaveData.instance.Over();
				Application.LoadLevel("defGameOver");
			}


			Destroy(gameObject);
			
		}

		transform.position = Vector3.MoveTowards (transform.position, PatrolPoint[currentPoint].position , moveSpeed * Time.deltaTime);
		//Debug.Log (currentPoint);
	}
}
