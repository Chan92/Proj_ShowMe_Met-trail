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
		CheckGameplay();
	}

	public void OpenMenu(bool open) {
		menu.SetActive(open);
		CheckGameplay();
	}

	public void OpenMap(bool open) {
		map.SetActive(open);
		CheckGameplay();
	}

	public void OpenMissies(bool open) {
		missies.SetActive(open);
		CheckGameplay();
	}

	public void OpenFabriek(bool open) {
		fabriek.SetActive(open);
		CheckGameplay();
	}

	public void OpenInventaris(bool open) {
		inventaris.SetActive(open);
		CheckGameplay();
	}

	public void OpenEncyclopedie(bool open) {
		encyclopedie.SetActive(open);
		CheckGameplay();
	}

	public void OpenHomebase(bool open) {
		homebase.SetActive(open);
		CheckGameplay();
	}

	public void OpenPlanet(bool open) {
		planet.SetActive(open);
		CheckGameplay();
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

	public void CheckGameplay() {
		if (map.activeInHierarchy || menu.activeInHierarchy || missies.activeInHierarchy || fabriek.activeInHierarchy ||
			inventaris.activeInHierarchy || encyclopedie.activeInHierarchy || homebase.activeInHierarchy) {
			Manager.inGameplay = false;
			game.SetActive(false);
		} else {
			Manager.inGameplay = true;
			game.SetActive(true);
		}
	}
}
