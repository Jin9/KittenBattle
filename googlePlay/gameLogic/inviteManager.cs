﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using System.Collections.Generic;

public class InviteManager{

	private static InviteManager sInstance = new InviteManager();
	public static InviteManager Instance {
		get {
			return sInstance;
		}
	}
	
	private Invitation mInvitation = null;
	private bool mShouldAutoAccept = false;
	
	public void OnInvitationReceived(Invitation inv, bool shouldAutoAccept) {
		mInvitation = inv;
		mShouldAutoAccept = shouldAutoAccept;
	}
	
	public Invitation Invitation {
		get {
			return mInvitation;
		}
	}
	
	public bool ShouldAutoAccept {
		get {
			return mShouldAutoAccept;
		}
	}
	
	public void DeclineInvitation() {
		if (mInvitation != null) {
			PlayGamesPlatform.Instance.RealTime.DeclineInvitation(mInvitation.InvitationId);
		}
		Clear();
	}
	
	public void Clear() {
		mInvitation = null;
		mShouldAutoAccept = false;
	}
}
