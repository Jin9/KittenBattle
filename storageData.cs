using UnityEngine;
using System.Collections;

public class storageData : MonoBehaviour {

	public static storageData instance;
	public int oldScore = 0;

	public int rankNum;

	public int myAtk;
	public int myDef;
	public int mySpd;

	public int atk1;
	public int atk2;
	public int atk3;
	public int atk4;
	public int atk5;

	public int def1;
	public int def2;
	public int def3;
	public int def4;
	public int def5;

	public int spd1;
	public int spd2;
	public int spd3;
	public int spd4;
	public int spd5;

	public string Aname1;
	public string Aname2;
	public string Aname3;
	public string Aname4;
	public string Aname5;

	public int Alv1;
	public int Alv2;
	public int Alv3;
	public int Alv4;
	public int Alv5;

	public string Dname1;
	public string Dname2;
	public string Dname3;
	public string Dname4;
	public string Dname5;
	
	public int Dlv1;
	public int Dlv2;
	public int Dlv3;
	public int Dlv4;
	public int Dlv5;

	public string Sname1;
	public string Sname2;
	public string Sname3;
	public string Sname4;
	public string Sname5;
	
	public int Slv1;
	public int Slv2;
	public int Slv3;
	public int Slv4;
	public int Slv5;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
