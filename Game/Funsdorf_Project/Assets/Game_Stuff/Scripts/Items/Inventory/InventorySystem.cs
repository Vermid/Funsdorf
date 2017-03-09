using UnityEngine;
using System.Collections;

public class InventorySystem : MonoBehaviour
{
    public ArrayList inventorySpace;
    private bool isActiveBag;

    void Start()
    {
        isActiveBag = false;
        inventorySpace = new ArrayList();
    }

    public void AddArmorToInventory(ArmorItems randomdrop)
    {
        inventorySpace.Add(new ArmorItems(randomdrop));
        if (MyConst.almir)
            Debug.Log("Random Item has successfully been added!");
    }

    public void AddWeaponToInventory(WeaponItems randomdrop)
    {
        inventorySpace.Add(new WeaponItems(randomdrop));
        if (MyConst.almir)
            Debug.Log("Random Item has successfully been added!");

    }

    public ArrayList GetInventory()
    {
        return inventorySpace;
    }

}

