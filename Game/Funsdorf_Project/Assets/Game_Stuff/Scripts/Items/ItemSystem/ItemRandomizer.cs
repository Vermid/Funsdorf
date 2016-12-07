using UnityEngine;
using System.Collections;

class ItemRandomizer : MonoBehaviour 
{
    ArmorItems randomArmor;
    WeaponItems randomWeapon;

    //calculation for the Dropchance 
    //save in int to check what dropped and if something dropped
    int RandomItemDropChance()
    {
        int Percentage = Random.Range(1, 101);

        if(Percentage>=50 && Percentage<=60)
        {
            Percentage = Random.Range(1, 11);
            if(Percentage >5)
            {
                return 1; //drop armor
            }
            else
            {
                return 2; //drop weapon
            }
        }
        return 0; //no drop
    }

    //creates the random item and after adds it to inventory
    //*int droppedItem* is the Return from RandomItemDropChance()
    void RandomItemCreator(int enemyLevel, int droppedItem)
    {
        if(droppedItem == 1)
        {
            
            randomArmor.CreateRandomArmor(droppedItem);
            AddArmorToInventory(randomArmor);
            
        }
        else if(droppedItem == 2  )
        {
            randomWeapon.CreateRandomWeapon(enemyLevel);
            AddWeaponToInventory(randomWeapon);
        }
    }

    void AddArmorToInventory(ArmorItems randomItem)
    {
        //Add functions for Inventory

    }

    void AddWeaponToInventory(WeaponItems randomItem)
    {
        //Add functions for Inventory
    }

}

