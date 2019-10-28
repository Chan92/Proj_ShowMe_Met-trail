using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverPlanet : MonoBehaviour{
	public GameObject[] planet;
	public GameObject[] player;
	private int layerId = 0;

	void Start(){
		SetLayer();
	}

    void Update(){
		if(Manager.androidBuild) {
			//android tap
		} else {
			if(!Manager.InteractionCheck()) {
				return;
			}

			if(Input.GetMouseButtonDown(0) && layerId < 2) {
				layerId++;
				SetLayer();
			}

			if(Input.GetMouseButtonDown(1) && layerId > 0) {
				layerId--;
				SetLayer();
			}
		}
    }

	void SetLayer() {
		for(int i = 0; i < planet.Length; i++) {
			planet[i].SetActive(false);
			player[i].SetActive(false);
		}

		planet[layerId].SetActive(true);
		player[layerId].SetActive(true);
	}

	private void OnDisable() {
		layerId = 0;
		SetLayer();
	}
}
