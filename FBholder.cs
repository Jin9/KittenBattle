using UnityEngine;
using System.Collections;

public class FBholder : MonoBehaviour {

	public void FBlogout(){
		if (FB.IsLoggedIn) {
			FB.Logout();
			Debug.Log (FB.IsLoggedIn);
			Application.LoadLevel("firstPage");
		}
	}
}
