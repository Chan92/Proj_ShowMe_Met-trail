using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCheatFix : MonoBehaviour{
	public Button mergeBt;

	public Sprite[] t0Sprite;
	public Sprite[] t1Sprite;
	public Sprite[] t2Sprite;
	public Sprite[] t3Sprite;

	public Item[] myItemList;

	private int counterPart1 = 0;
	private int counterPart2 = 0;
	private bool part1;

	void Start() {
		myItemList[0].UpdateItem(t1Sprite[0]);
		myItemList[1].UpdateItem(t1Sprite[1]);
		myItemList[2].UpdateItem(t1Sprite[2]);
		myItemList[3].UpdateItem(t1Sprite[3]);
	}

	public void UpdateSprite() {
		if(part1) {
			if(counterPart1 == 0 && counterPart2 == 0) {
				SetSprite(1);
				counterPart1++;
			} else if(counterPart1 == 0 && counterPart2 == 1) {
				SetSprite(3);
				counterPart1++;
			} else {
				SetSprite(4);
			}
		} else {
			if(counterPart1 == 0 && counterPart2 == 0) {
				SetSprite(2);
				counterPart2++;
			} else if(counterPart1 == 1 && counterPart2 == 0) {
				SetSprite(3);
				counterPart2++;
			} else {
				SetSprite(4);
			}
		}
	}

	void SetSprite(int type) {
		if(type == 1) {
			myItemList[0].UpdateItem(t2Sprite[0]);
			myItemList[1].UpdateItem(t1Sprite[2]);
			myItemList[2].UpdateItem(t1Sprite[3]);
			myItemList[3].UpdateItem(t0Sprite[0]);
		} else if(type == 2) {
			myItemList[0].UpdateItem(t1Sprite[0]);
			myItemList[1].UpdateItem(t1Sprite[1]);
			myItemList[2].UpdateItem(t2Sprite[1]);
			myItemList[3].UpdateItem(t0Sprite[0]);
		} else if(type == 3) {
			myItemList[0].UpdateItem(t2Sprite[0]);
			myItemList[1].UpdateItem(t2Sprite[0]);
			myItemList[2].UpdateItem(t0Sprite[0]);
			myItemList[3].UpdateItem(t0Sprite[0]);
		} else if(type == 4) {
			myItemList[0].UpdateItem(t3Sprite[0]);
			myItemList[1].UpdateItem(t0Sprite[0]);
			myItemList[2].UpdateItem(t0Sprite[0]);
			myItemList[3].UpdateItem(t0Sprite[0]);
		}
	}

	public void CheckSelected() {
		if(myItemList[0].selected && myItemList[1].selected && !myItemList[2].selected && !myItemList[3].selected) {
			part1 = true;
			mergeBt.interactable = true;
		} else if(myItemList[2].selected && myItemList[3].selected && !myItemList[0].selected && !myItemList[1].selected) {
			part1 = false;
			mergeBt.interactable = true;
		} else {
			mergeBt.interactable = false;
		}
	}

}
