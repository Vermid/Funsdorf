using UnityEngine;
using System.Collections;

class ItemRandomizer : MonoBehaviour
{
    private ArmorItems randomArmor;
    private WeaponItems randomWeapon;
    private InventorySystem inventorySpace;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventorySpace = player.GetComponent<InventorySystem>();
        randomArmor = new ArmorItems();
        randomWeapon = new WeaponItems();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            RandomItemDropChance(10);
        }
        Destroy(gameObject);
    }

    //calculation for the Dropchance of itemtype
    void RandomItemDropChance(int enemyLevel)
    {
        int Percentage;

        Percentage = Random.Range(1, 11);
        if (Percentage > 5)
        {
            randomArmor.CreateRandomArmor(enemyLevel);
            Debug.Log("Random Item was Successfully Created!");
            inventorySpace.AddArmorToInventory(randomArmor);
        }
        else
        {
            randomWeapon.CreateRandomWeapon(enemyLevel);
            Debug.Log("Random Item was Successfully Created!");
            inventorySpace.AddWeaponToInventory(randomWeapon);
        }
    }


}

