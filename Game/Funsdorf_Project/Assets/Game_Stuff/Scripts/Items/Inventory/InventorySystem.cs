using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public ArrayList inventorySpace;
    private bool isActiveBag;
    public Text itemLog;
    private ItemStructure itemStructure;
    void Start()
    {
        isActiveBag = false;
        inventorySpace = new ArrayList();
        itemStructure = new ItemStructure();
    }
    public void AddArmorToInventory(ArmorItems randomdrop)
    {
        inventorySpace.Add(new ArmorItems(randomdrop));
        if (MyConst.almir)
            Debug.Log("Random Item has successfully been added!");
        itemLog.text += randomdrop.GetItemName() + "\n";
    }

    public void AddWeaponToInventory(WeaponItems randomdrop)
    {
        inventorySpace.Add(new WeaponItems(randomdrop));
        if (MyConst.almir)
            Debug.Log("Random Item has successfully been added!");
        itemLog.text += randomdrop.GetItemName() +"\n";
    }

    public ArrayList GetInventory()
    {
        return inventorySpace;
    }
}

