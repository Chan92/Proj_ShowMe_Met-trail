using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Phrobes : MonoBehaviour{
	public Transform[] phrobes;
	public RectTransform[] rectPhrobes;
	public float moveSpeed = 25f;
	public Transform spawner;
	private bool probesActive;

	void Start(){
		EnablePhrobes(false);
	}

	void Update() {
		if(Manager.androidBuild) {
			AndroidUpdate();
		} else {
			PcUpdate();
		}		

		if(DiscoverPermission() && probesActive) {
			Discover();
		}
	}

	void AndroidUpdate() {
		//android shoot prhobes
		//android move phrobes
	}

	void PcUpdate() {
		if(!Manager.InteractionCheck()) {
			return;
		}

		if(Input.GetMouseButtonDown(0) && probesActive) {
			StartCoroutine(MovePosition(phrobes[0], Input.mousePosition));
		}

		if(Input.GetMouseButtonDown(1) && probesActive) {
			StartCoroutine(MovePosition(phrobes[1], Input.mousePosition));
		}

		if(Input.GetMouseButtonDown(0) && !probesActive) {
			EnablePhrobes(true);
			SpaceField.radarOut = true;
		}

		if(Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1)) {
			EnablePhrobes(false);
			SpaceField.radarOut = false;
		}
	}

	void Discover() {
		//print("discover");
	}

	void EnablePhrobes(bool active) {
		phrobes[0].gameObject.SetActive(active);
		phrobes[1].gameObject.SetActive(active);
		probesActive = active;
	}

	IEnumerator MovePosition(Transform obj, Vector3 pos) {
		Vector3 dir = obj.position - pos;
		while(Vector3.Distance(obj.position, pos) > 0.1f * moveSpeed) {
			obj.position -= dir.normalized * moveSpeed * Time.deltaTime;
			yield return null;
		}

		obj.position = pos;
	}

	bool DiscoverPermission() {
		return Vector3.Distance(rectPhrobes[0].position, rectPhrobes[1].position) < rectPhrobes[0].rect.width /4 - 2f;
	}
}
