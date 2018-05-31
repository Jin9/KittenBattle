using UnityEngine;
using System.Collections;

public class ChangeTexture : MonoBehaviour {

	public static ChangeTexture instance;
	// Use this for initialization
	void Start () {

		instance = this;
		//Texture tex = Resources.Load("cu_cat_b_col_low",Texture);
		//renderer.material.mainTexture = Resources.Load("cu_cat_b_col_low",typeof(Texture))as Texture;
	}

	public void change(string pic){
		GetComponent<Renderer>().material.mainTexture = Resources.Load(pic,typeof(Texture))as Texture;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
