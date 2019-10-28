using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour{
	public ItemGrade grade;
	public ItemType type;
	public Sprite icon;
	public bool selected = false;

	private void Start() {
		icon = GetComponent<Image>().sprite;
	}
}
