using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class login : MonoBehaviour {

	public void Click(){

		Social.localUser.Authenticate((bool success) =>
		                              {
			if (success)
			{
				Debug.Log("ooooJinoooo You've successfully logged in");
				firstManeger.instance.state = 5;
				Debug.Log ("state is " + firstManeger.instance.state);
				Application.LoadLevel ("loadScreen");

			}
			else
			{
				Debug.Log("ooooJinoooo Login failed for some reason");
			}
		});


	}
}
