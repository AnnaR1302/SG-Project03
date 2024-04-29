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

    public int changeInventory(string type, float range, float rof, float damage, WeaponControllerScript weapon)
    {
        WeaponScript weaponToAdd = new WeaponScript(type, range, rof, damage, weapon);
        Debug.Log(weaponToAdd.getName());
        inventory.Add(weaponToAdd);
        return getCurrentIndex();
    }

    public WeaponScript retrieveInventoryElement(int index) 
    {
        return inventory[index];
    }

    public int getCurrentIndex()
    {
        int currentIndex = inventory.Count - 1;
        return currentIndex;
    }
}
