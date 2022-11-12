using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    public static ItemSlots instance;
    public ItemSlotMini[] slotMinis;
    [SerializeField] Image[] bgSlots;

    bool slotState;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < slotMinis.Length; i++)
        {
            if (!slotMinis[i].isItem)
            {
                slotMinis[i].gameObject.SetActive(false);
            }
            else
            {
                slotMinis[i].gameObject.SetActive(true);
            }
        }
    }
    private void Update()
    {
        foreach (var slot in slotMinis)
        {
            if (!slot.isItem)
            {
                slot.gameObject.SetActive(false);
            }
            else
            {
                slot.gameObject.SetActive(true);
            }
        }
    }
    public void AddItemToSlot(int itemID)
    {
        for (int i = 0; i < slotMinis.Length; i++)
        {
            if (!slotMinis[i].isItem)
            {
                slotMinis[i].gameObject.SetActive(true);
                slotMinis[i].GetComponent<Image>().sprite = ItemManager.instance.itemSprite[itemID];
                slotMinis[i].itemID = itemID;
                slotMinis[i].isItem = true;
                slotMinis[i].itemType = ItemManager.instance.ReturnItemType(itemID);
                slotMinis[i].itemType.isEquip = true;
                slotMinis[i].itemLevel++;
                return;
            }
            else //upgrade
            {
                if (slotMinis[i].itemID == itemID)
                {
                    slotMinis[i].itemLevel++;
                    return;
                }
            }
        }
    }

    public void ButtonDumpStateSwitch()
    {
        if (!slotState) //active dump mode
        {
            foreach (var slot in slotMinis)
            {
                slot.slotState = false;
            }
            foreach (var bg in bgSlots)
            {
                bg.color = Color.red;
            }
            slotState = true;
        }
        else
        {
            foreach (var slot in slotMinis)
            {
                slot.slotState = true;
            }
            foreach (var bg in bgSlots)
            {
                bg.color = Color.white;
            }
            slotState = false;
        }
    }
}
