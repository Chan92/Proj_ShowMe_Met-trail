using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour{
	public bool androidBuildSetup = false;
	static public bool androidBuild;

	private void Awake() {
		androidBuild = androidBuildSetup;
	}
}
