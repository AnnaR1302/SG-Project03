using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<WeaponScript> inventory = new List<WeaponScript>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeInventory(string type, float range, float rof, float damage, WeaponControllerScript weapon)
    {
        WeaponScript weaponToAdd = new WeaponScript(type, range, rof, damage, weapon);
        Debug.Log(weaponToAdd.getName());
        inventory.Add(weaponToAdd);
    }

    public WeaponScript retrieveInventoryElement(int index) 
    {
        return inventory[index];
    }

    public int getInventoryLength()
    {
        return inventory.Count;
    }
}
