using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setLoad : MonoBehaviour {

	public RawImage l;
	public RawImage o;
	public RawImage a;
	public RawImage d;
	public RawImage i;
	public RawImage n;
	public RawImage g;
	public RawImage d1;
	public RawImage d2;
	public RawImage d3;

	float t = 0.0f;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		l.gameObject.SetActive (false);
		o.gameObject.SetActive (false);
		a.gameObject.SetActive (false);
		d.gameObject.SetActive (false);
		i.gameObject.SetActive (false);
		n.gameObject.SetActive (false);
		g.gameObject.SetActive (false);
		d1.gameObject.SetActive (false);
		d2.gameObject.SetActive (false);
		d3.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		t += Time.deltaTime;
		if(t > 0.7f){
			t = 0.0f;
		}
		else if(t > 0.6f){
			l.gameObject.SetActive (false);
			o.gameObject.SetActive (false);
			a.gameObject.SetActive (false);
			d.gameObject.SetActive (false);
			i.gameObject.SetActive (false);
			n.gameObject.SetActive (false);
			g.gameObject.SetActive (false);
			d1.gameObject.SetActive (false);
			d2.gameObject.SetActive (false);
			d3.gameObject.SetActive (false);
		}
		else if(t > 0.5f ){
			d3.gameObject.SetActive(true);
		}
		else if(t > 0.45f ){
			d2.gameObject.SetActive(true);
		}
		else if(t > 0.4f ){
			d1.gameObject.SetActive(true);
		}
		else if(t > 0.35f ){
			g.gameObject.SetActive(true);
		}
		else if(t > 0.3f ){
			n.gameObject.SetActive(true);
		}
		else if(t > 0.25f ){
			i.gameObject.SetActive(true);
		}
		else if(t > 0.2f ){
			d.gameObject.SetActive(true);
		}
		else if(t > 0.15f){
			a.gameObject.SetActive(true);
		}
		else if (t > 0.1f) {
			o.gameObject.SetActive (true);	
		}
		else if (t > 0.05f) {
			l.gameObject.SetActive (true);	
		}
	}
}
