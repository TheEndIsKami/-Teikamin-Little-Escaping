using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupWhenLevelUp : MonoBehaviour
{
    public static PopupWhenLevelUp instance;

    [SerializeField] ChoiceBuffButton[] listChoosingItems;
    [SerializeField] TextMeshProUGUI[] itemTextDescription;
    private void Start()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ChooseItems()
    {
        //random item in list
        for (int indexItem = 0; indexItem < listChoosingItems.Length; indexItem++)
        {
            int itemID = 0;
            int itemLevel = 1;
            List<int> currentListItemID = new List<int>();
            List<int> currentListItemLevel = new List<int>();
            foreach (ItemSlotMini slot in ItemSlots.instance.slotMinis)
            {
                if (!slot.isItem)
                {
                    itemID = Random.Range(0, ItemManager.instance.itemSprite.Length);
                    currentListItemID.Add(itemID);
                }
                else
                {
                    currentListItemID.Add(slot.itemID);
                }
            }
            int index = Random.Range(0, currentListItemID.Count);
            itemID = currentListItemID[index];

            foreach (ItemSlotMini slot in ItemSlots.instance.slotMinis)
            {
                if (slot.itemID == itemID && slot.isItem)
                {
                    itemLevel = slot.itemLevel + 1;
                    break;
                }
                else
                {
                    itemLevel = 1;
                }
            }

            listChoosingItems[indexItem].itemID = itemID;
            listChoosingItems[indexItem].GetComponent<Image>().sprite = ItemManager.instance.itemSprite[itemID];
            itemTextDescription[indexItem].text = "itemID: " + itemID + ". Level " + itemLevel + " : "+ ItemManager.instance.ReturnItemTextDes(itemID, itemLevel);
        }
        //pause time
        Time.timeScale = 0f;
    }

    public void ClosePopup()
    {
        //close
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
