using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemGrade {
	tier_0,
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
	public List<Item> myItems = new List<Item>();
	public Sprite[] sprites;
	public Sprite[] t0Sprites;
	public Sprite[] t1Sprites;
	public Sprite[] t2Sprites;
	public Sprite[] t3Sprites;
	//public Sprite[][] itemSprite;
	public Image bigIcon;

	private int t1Id = 0;
	private int t2Id = 0;

	void Start() {
		AllowMerge();
		IconCheck();
	}

	public void Merge() {
		for (int i = 1; i < savedItems.Count; i++) {
			savedItems[i].grade = ItemGrade.tier_0;
			savedItems[i].selected = false;
		}

		savedItems[0].grade++;
		savedItems[0].selected = false;				
		IconCheck();
		bigIcon.sprite = savedItems[0].icon;

		savedItems.Clear();
	}

	void IconCheck() {
		for (int i = 0; i < myItems.Count; i++) {
			if (myItems[i].grade == ItemGrade.tier_0) {
				myItems[i].UpdateItem(t0Sprites[0]);

			} else if (myItems[i].grade == ItemGrade.tier_1) {
				myItems[i].UpdateItem(t1Sprites[t1Id]);
				t1Id++;

			} else if(myItems[i].grade == ItemGrade.tier_2) {
				myItems[i].UpdateItem(t2Sprites[t2Id]);
				t2Id++;

			} else if(myItems[i].grade == ItemGrade.tier_3) {
				myItems[i].UpdateItem(t3Sprites[0]);

			}
		}
	}

	public void MergeQueue(Item item) {
		if (item.selected) {
			savedItems.Remove(item);
		} else {
			savedItems.Add(item);
			bigIcon.sprite = item.icon;
		}

		item.selected = !item.selected;
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
