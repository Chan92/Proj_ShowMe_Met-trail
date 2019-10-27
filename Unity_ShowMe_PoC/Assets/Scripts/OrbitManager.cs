using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager: MonoBehaviour{
	private Touch touch;
	private Vector2 touchPosition;
	private Quaternion rotationZ;
	private Transform planet;
	
	[SerializeField]
	private float rotateSpeed = 10f;
	[SerializeField]
	private Vector2 zoomMinMax = new Vector2(1f, 5f);
	[SerializeField]
	private Transform map;
	[SerializeField]
	private Transform[] orbits;
	[SerializeField]
	private Transform playerMark;
	[SerializeField]
	private bool allowPlanetRotate = true;

	public void ScaleMap() {
		float zooming = Input.GetAxis("Mouse ScrollWheel");
		if(zooming != 0) {
			Vector3 newscale = new Vector3(zooming, zooming);

			if(map.localScale.x + newscale.x < zoomMinMax.x) {
				map.localScale = Vector3.one;
			} else if(map.localScale.x + newscale.x > zoomMinMax.y) {
				map.localScale = new Vector3(5, 5);
			} else {
				map.localScale += newscale;
			}
		}
	}

	private void Update() {
		if(Manager.androidBuild) {
			AndroidRotate();
			//android scale
		} else {
			ScaleMap();
		}
	}

	private void AndroidRotate() {
		if(Input.touchCount > 0) {
			touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Moved) {
				rotationZ = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * rotateSpeed);

				transform.rotation = rotationZ * transform.rotation;
			}
		}
	}

	public void GetPlanetOrbit(Transform _planet) {
		planet = _planet;
	}

	public void RotatePlanetOrbit() {
		if(planet && allowPlanetRotate) {
			float rot = Input.GetAxis("Mouse X") * rotateSpeed;
			planet.Rotate(0, 0, rot);
		}
	}

	public void EndPlanetOrbit() {
		planet = null;
	}

	public void OrbitRotate(float direction) {
		//map.Rotate(0, 0, direction * rotateSpeed);
		for(int i = 0; i < orbits.Length; i++) {
			orbits[i].Rotate(0, 0, direction * rotateSpeed);
		}
	}
}
