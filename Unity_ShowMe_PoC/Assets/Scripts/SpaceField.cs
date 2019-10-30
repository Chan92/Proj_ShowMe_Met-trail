using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceField : MonoBehaviour{
	public Vector2 zoomMinMax = new Vector2(1f, 5f);
	public Transform spaceShip;
	public Transform planet;	
	public Transform spaceObjects;
	public Transform[] spaceTrash;
	public Transform[] bottomLeftOuter;
	public Transform bottomLeft;
	public Transform topRight;
	public float moveSpeed = 1f;

	private bool radarOut = false;

	void Start(){
        
    }

    void Update(){
		ScaleField();

		if (Manager.inGameplay) {
			if(!radarOut) {
				MoveForward();
			} else {
				for(int i = 0; i < spaceTrash.Length; i++) {
					spaceTrash[i].position = Vector3.MoveTowards(spaceTrash[i].position, bottomLeftOuter[i].position, moveSpeed * Time.deltaTime);
				}
			}
		}	
	}

	public void MoveForward() {
		spaceObjects.position = Vector3.MoveTowards(spaceObjects.position, bottomLeft.position, moveSpeed * Time.deltaTime);
	}

	public void ScaleField() {
		float zooming = Input.GetAxis("Mouse ScrollWheel");
		if(zooming != 0) {
			Vector3 newscale = new Vector3(zooming, zooming);

			if(transform.localScale.x + newscale.x < zoomMinMax.x) {
				transform.localScale = Vector3.one;
			} else if(transform.localScale.x + newscale.x > zoomMinMax.y) {
				transform.localScale = Vector3.one * zoomMinMax.y;
			} else {
				transform.localScale += newscale;
			}
		}
	}
}
