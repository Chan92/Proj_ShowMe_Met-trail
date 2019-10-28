using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemGrade {
	tier_1,
	tier_2,
	tier_3
};

public enum ItemType {
	trash,
	wheels,
	body,
	robot
};

public class ItemsManager :MonoBehaviour {
	public Button mergeButton;

	private Item selectedItem;
	private List<Item> savedItems = new List<Item>();


	void Start() {

	}

	void Merge() {
	


	}

	public void AddMergeQueue(Item item) {
		savedItems.Add(item);
		AllowMerge();
	}

	public void RemoveMergeQueue(Item item) {
		savedItems.Remove(item);
		AllowMerge();
	}

	void AllowMerge() {
		if (savedItems.Count <= 1) {
			mergeButton.interactable = false;
			return;
		}

		ItemGrade gradeItem1 = savedItems[0].grade;
		for (int i = 1; i < savedItems.Count; i++) {
			if (savedItems[i].grade != gradeItem1) {
				mergeButton.interactable = false;
				return;
			}
		}

		mergeButton.interactable = true;
	}
}
