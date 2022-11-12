using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceBuffButton : MonoBehaviour
{
    public int itemID;

    public void AddBuff()
    {
        //picked
        ItemSlots.instance.AddItemToSlot(itemID);
    }
}
