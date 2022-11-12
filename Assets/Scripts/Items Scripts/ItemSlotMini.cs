using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotMini : MonoBehaviour
{
    public int itemID;
    public int itemLevel;
    public bool isItem;
    public bool slotState;
    [SerializeField] GameObject itemOnGroundPrefab;

    public Item itemType;

    Image thisImage;
    private void Start()
    {
        slotState = true;
        thisImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (itemType.skillCDCD >= 0f && itemType.skillCD != 0f)
        {
            thisImage.fillAmount = 1- itemType.skillCDCD / itemType.skillCD;
        }
        if (itemType.skillCD == 0f)
        {
            thisImage.fillAmount = 1f;
        }
    }
    public void ActiveSlot()
    {
        if (slotState)
        {
            Debug.Log("Active Item ID: " + itemID);
        }
        else
        {
            isItem = false;
            itemType.isEquip = false;
            itemType.Unequip();
            GameObject itemDrop = Instantiate(itemOnGroundPrefab, PlayerController.instance.transform.position, Quaternion.identity);
            itemDrop.GetComponent<ItemPickUp>().itemID = (ItemManager.ItemCode)itemID;
        }
    }
}
