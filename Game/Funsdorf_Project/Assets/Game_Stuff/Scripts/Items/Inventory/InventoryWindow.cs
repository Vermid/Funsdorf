using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    InventorySystem inventory;
    GameObject player;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<InventorySystem>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inventory.inventorySpace[0] is ArmorItems)
            Debug.Log("armor");
        else
            Debug.Log("Weapon");
	}
}
