using UnityEngine;
using System.Collections;

public class ran3 : MonoBehaviour {

	public GameObject rat;
	// Use this for initialization
	void Start () {
		StartCoroutine (spawn());
		//Invoke ("spawn",1);
	}
	
	IEnumerator spawn(){
		
		float spawnDelay;
		
		while(true) {
			spawnDelay = Random.Range(1f,4f);
			yield return new WaitForSeconds(spawnDelay);
			Instantiate(rat);
			

		}

		
	}
}
