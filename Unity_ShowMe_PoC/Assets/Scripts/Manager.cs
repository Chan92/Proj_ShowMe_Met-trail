using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour{
	public bool androidBuildSetup = false;
	static public bool androidBuild;

	public GameObject myCanvas;
	static public GameObject canvas;
	static public GraphicRaycaster gRay;
	static public PointerEventData pointerData;
	static public EventSystem eventSystem;
	static public bool inGameplay;

	private void Awake() {
		canvas = myCanvas;
		androidBuild = androidBuildSetup;
	}

	private void Start() {
		gRay = canvas.GetComponent<GraphicRaycaster>();
		eventSystem = canvas.GetComponent<EventSystem>();
	}

	//check if clicked on a button
	static public bool InteractionCheck() {		
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
			pointerData = new PointerEventData(eventSystem);
			pointerData.position = Input.mousePosition;

			List<RaycastResult> results = new List<RaycastResult>();

			gRay.Raycast(pointerData, results);

			foreach(RaycastResult result in results) {
				if(result.gameObject.GetComponent<Button>()) {
					//if clicked on a button ignore click interactions
					return false;
				}
			}
		}

		//may use button interactions
		return true;
	}

}
