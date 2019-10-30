using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour{
	public float speed = 20f;
	public float maxScale;

    void Update(){
		if (transform.localScale.x < maxScale) {
			transform.localScale += Vector3.one * speed * Time.deltaTime;
		}		
    }
}
