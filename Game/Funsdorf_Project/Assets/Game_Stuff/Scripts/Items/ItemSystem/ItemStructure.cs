using UnityEngine;
using System.Collections;


public class ItemStructure
{
    private string itemName;    //Name vom Item
    private int itemRarity;  //Seltenheit von 0 bis 5
    private int itemType;  //ItemType 0-3

    ///////////////////////
    //GET AND SET METHODS//
    ///////////////////////

    //basis Class Items
    public void SetItemName(string sItemName)
    {
        itemName = sItemName;
    }
    public string GetItemName() { return itemName; }
    public void SetItemRarity(int nRarity)
    {
        itemRarity = nRarity;
    }
    public int GetItemRarity() { return itemRarity; }
    public void SetItemType(int nItemType)
    {
        itemType = nItemType;
    }
    public int GetItemType() { return itemType; }
}

