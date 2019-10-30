using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour{
	public GameObject map;
	public GameObject menu;
	public GameObject game;
	public GameObject missies;
	public GameObject fabriek;
	public GameObject inventaris;
	public GameObject encyclopedie;
	public GameObject homebase;
	public GameObject planet;

	void Start(){
		DisableAll();
		game.SetActive(true);
	}

	public void OpenMenu(bool open) {
		menu.SetActive(open);
	}

	public void OpenMap(bool open) {
		map.SetActive(open);
	}

	public void OpenMissies(bool open) {
		missies.SetActive(open);
	}

	public void OpenFabriek(bool open) {
		fabriek.SetActive(open);
	}

	public void OpenInventaris(bool open) {
		inventaris.SetActive(open);
	}

	public void OpenEncyclopedie(bool open) {
		encyclopedie.SetActive(open);
	}

	public void OpenHomebase(bool open) {
		homebase.SetActive(open);
	}

	public void OpenPlanet(bool open) {
		planet.SetActive(open);
	}

	public void DisableAll() {
		map.SetActive(false);
		menu.SetActive(false);
		missies.SetActive(false);
		fabriek.SetActive(false);
		inventaris.SetActive(false);
		encyclopedie.SetActive(false);
		homebase.SetActive(false);
	}
}
