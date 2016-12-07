using UnityEngine;
using System.Collections;

class WeaponItems : ItemStructure
{
    private int weaponType; //Art von Waffe
    private float weaponAttackspeed; //Angriffsgeschwindigkeit
    private float weaponDamage;  //Schaden für die Waffe

    //CONSTRUCTORS//
    WeaponItems()
    {
        SetItemName("");
        SetItemRarity(0);
        SetItemType(0);
        SetWeaponType(0);
        SetWeaponAttackspeed(0);
        SetWeaponDamage(0);
    }
    WeaponItems(string sItemName, int nItemRarity, int nWeaponType, float fWeaponAttackspeed, float fWeaponDamage)
    {
        SetItemName(sItemName);
        SetItemRarity(nItemRarity);
        SetItemType(2);
        SetWeaponType(nWeaponType);
        SetWeaponAttackspeed(fWeaponAttackspeed);
        SetWeaponDamage(fWeaponDamage);

    }
    //END OF CONSTRUCTORS//

    //CREATE FUNCTIONS//
    public void CreateRandomWeapon(int nEntityLevel)
    {
        int nRNGPercentage;
        string namePrefix;
        //Rarity
        // 60 % chance for uncommon
        // 20 % for Common
        // 10 % for Rare
        //  9 % for Epic
        //  1 % for Legendary
        SetItemType(2);

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

        // 10% chance for each one
        nRNGPercentage = Random.Range(1, 61);
        if (nRNGPercentage <= 10)
        {
            weaponType = 1; //Wand or Book two-handed
            weaponDamage = Random.Range(11, 14) + nEntityLevel;
            weaponAttackspeed = Random.Range(0.4f, 0.8f);
            namePrefix = namePrefix + " Book";
        }
        else if (nRNGPercentage <= 20)
        {
            weaponType = 2; //Staff two-handed
            weaponDamage = Random.Range(10, 16) + nEntityLevel;
            weaponAttackspeed = Random.Range(0.3f, 0.7f);
            namePrefix = namePrefix + " Staff";
        }
        else if (nRNGPercentage <= 30)
        {
            weaponType = 3; //Sword one-handed
            weaponDamage = Random.Range(3, 8) + nEntityLevel;
            weaponAttackspeed = Random.Range(1.5f, 1.8f);
            namePrefix = namePrefix + " One-handed Sword";
        }
        else if (nRNGPercentage <= 40)
        {
            weaponType = 4; // Sword two handed
            weaponDamage = Random.Range(7, 11) + nEntityLevel;
            weaponAttackspeed = Random.Range(1.1f, 1.3f);
            namePrefix = namePrefix + " Two-handed Sword";
        }
        else if (nRNGPercentage <= 50)
        {
            weaponType = 5; //Bow two-handed
            weaponDamage = Random.Range(10, 16) + nEntityLevel;
            weaponAttackspeed = Random.Range(0.6f, 1.0f);
            namePrefix = namePrefix + " Bow";
        }
        else
        {
            weaponType = 6; //Shield one-handed
            weaponDamage = 0;
            weaponAttackspeed = Random.Range(1.4f, 1.6f);
            namePrefix = namePrefix + " Shield";
        }

        SetItemName(namePrefix);

    }
    //END OF CREATE FUNCTIONS//

    //GET AND SET METHODS//
    void SetWeaponType(int nWeaponType)
    {
        weaponType = nWeaponType;
    }

    int GetWeaponType() { return weaponType; }

    void SetWeaponAttackspeed(float fWeaponAttackspeed)
    {
        weaponAttackspeed = fWeaponAttackspeed;
    }

    float GetWeaponAttackspeed() { return weaponAttackspeed; }

    void SetWeaponDamage(float fWeaponDamage)
    {
        weaponDamage = fWeaponDamage;
    }

    float GetWeaponDamage() { return weaponDamage; }
    //END OF GET AND SET METHODS//
}

