using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour{
	public Vector3 rotateSpeed = new Vector3(0, 0, 20);

	void Update() {
		transform.Rotate(new Vector3(rotateSpeed.x * Time.deltaTime, rotateSpeed.y * Time.deltaTime, rotateSpeed.z * Time.deltaTime));
	}
}
