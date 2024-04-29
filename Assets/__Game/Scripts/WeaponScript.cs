using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript
{
    string weaponType;
    float weaponRange;
    float rateOfFire;
    float weaponDamage;
    WeaponControllerScript weapon;

    public WeaponScript()
    {

    }
    public WeaponScript(string type, float range, float rof, float damage, WeaponControllerScript weaponObject)
    {
        weaponType = type;
        weaponRange = range;
        weaponDamage = damage;
        rateOfFire = rof;
        weapon = weaponObject;
    }
    

    public string getName()
    {
        return weaponType;
    }

    public WeaponControllerScript getObject()
    {
        return weapon;
    }
    public float GetRange()
    {
        return weaponRange;
    }
    public float GetDamage()
    {
        return weaponDamage;
    }

}
