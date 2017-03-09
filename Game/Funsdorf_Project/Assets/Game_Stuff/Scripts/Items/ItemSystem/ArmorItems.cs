using UnityEngine;
using System.Collections;

 public class ArmorItems : ItemStructure
{
    private int armorSlot; // Slot 0-5
    private float armorValue; // How much armor the Item has

    //CONSTRUCTORS//
    public ArmorItems()
    {
        SetItemName("");
        SetItemRarity(0);
        SetItemType(0);
        SetArmorSlot(0);
        SetArmorValue(0);
    } //standard
    public ArmorItems(string sItemName, int nItemRarity,int nArmorSlot, float fArmorValue)//Overloaded (without Itemtype parameter since its armor)
    {
        SetItemName(sItemName);
        SetItemRarity(nItemRarity);
        SetItemType(1);
        SetArmorSlot(nArmorSlot);
        SetArmorValue(fArmorValue);   
    }
    public ArmorItems(ArmorItems orig)
    {
        SetItemName(orig.GetItemName());
        SetItemRarity(orig.GetItemRarity());
        SetItemType(orig.GetItemType());
        SetArmorSlot(orig.GetArmorSlot());
        SetArmorValue(orig.GetArmorValue());
    }
    //END OF CONSTRUCTORS//

    //CREATE FUNCTIONS//
    public ArmorItems CreateRandomArmor(int nEntityLevel )
    {
        int nRNGPercentage;
        string namePrefix;
        //Rarity
        // 60 % chance for uncommon
        // 20 % for Common
        // 10 % for Rare
        //  9 % for Epic
        //  1 % for Legendary
        SetItemType(1);

        nRNGPercentage = Random.Range(0, 100001);
        if (nRNGPercentage <= 60000)
        {
            SetItemRarity(2);       //Common(grey)            
            namePrefix = "Common";
        }
        else if (nRNGPercentage <= 80000)
        {
            SetItemRarity(3);      //uncommon(white)          
            namePrefix = "Uncommon";
        }
        else if (nRNGPercentage <= 90000)
        {
            SetItemRarity(4);      //Rare(blue)       
            namePrefix = "Rare";
        }
        else if (nRNGPercentage <= 99000)
        {
            SetItemRarity(5);      //epic(purple)    
            namePrefix = "Epic";
        }
        else
        {
            SetItemRarity(6);      //Legendary(orange)
            namePrefix = "Legendary";
        }

        //Slot Randomizer
        nRNGPercentage = Random.Range(1, 101);
        if (nRNGPercentage <= 25)
        {
            armorSlot = 1; //Head
            namePrefix = namePrefix + " Helmet";
            armorValue = Random.Range(5, 11) + nEntityLevel;
        }
        else if (nRNGPercentage <= 50)
        {
            armorSlot = 2; // Chest
            namePrefix = namePrefix + " Chestpiece";
            armorValue = Random.Range(15, 21) + nEntityLevel;
        }
        else if (nRNGPercentage <= 75)
        {
            armorSlot = 3; //Legs and Feet
            namePrefix = namePrefix + " Pants and Shoes";
            armorValue = Random.Range(10, 16) + nEntityLevel;
        }
        else if (nRNGPercentage <= 100)
        {
            armorSlot = 4; //Hands
            namePrefix += " Gloves";
            armorValue = Random.Range(3, 7) + nEntityLevel;
        }

        SetItemName(namePrefix);

        if (MyConst.almir)
        {
            Debug.Log(namePrefix);
            Debug.Log("Random Armor successfully created!");
        }
        return this;
    }
    //END OF CREATE FUNCTIONS//

    //GET AND SET METHODS//
    void SetArmorSlot(int nArmorSlot)
    {
        if ((nArmorSlot > 5) || (nArmorSlot < 0))
            return;   
        armorSlot = nArmorSlot;
    }
    int GetArmorSlot() { return armorSlot; }
    void SetArmorValue( float fArmorValue)
    {
        if (fArmorValue < 0)
            return;
        armorValue = fArmorValue;
    }
    float GetArmorValue() { return armorValue; }
    //END OF GET AND SET METHODS//
}

