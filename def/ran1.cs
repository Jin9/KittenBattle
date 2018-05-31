using UnityEngine;
using System.Collections;

public class ran1 : MonoBehaviour {
	
	public GameObject rat;

	// Use this for initialization
	void Start () {
		//Invoke ("spawn",1);
		StartCoroutine (spawn());
	}

	IEnumerator spawn(){
//		int count = 0;
		float spawnDelay;

		while(true) {
			spawnDelay = Random.Range(1f,4f);
			yield return new WaitForSeconds(spawnDelay);
			Instantiate(rat);
		}


	}

}
