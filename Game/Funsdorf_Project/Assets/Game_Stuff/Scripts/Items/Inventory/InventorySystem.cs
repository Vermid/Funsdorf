using UnityEngine;
using System.Collections;

public class InventorySystem : MonoBehaviour 
{
    public  ArrayList inventorySpace;
    private bool isActiveBag;
    private GameObject Bag;

    void Start()
    {
        Bag = GameObject.FindGameObjectWithTag("UIBag");
        isActiveBag = false;
        inventorySpace = new ArrayList();
    }

    void Update()
    {
        if (Input.GetButtonDown("Bag")) 
        {
            isActiveBag = !isActiveBag;
        }
        Bag.SetActive(isActiveBag);
    }


    public void AddArmorToInventory(ArmorItems randomdrop)
    {
        inventorySpace.Add(new ArmorItems(randomdrop));
        Debug.Log("Random Item has successfully been added!");
    }

    public void AddWeaponToInventory(WeaponItems randomdrop)
    {
        inventorySpace.Add(new WeaponItems(randomdrop));
        Debug.Log("Random Item has successfully been added!");
        
    }

    public ArrayList GetInventory()
    {
        return inventorySpace;
    }
  
}

