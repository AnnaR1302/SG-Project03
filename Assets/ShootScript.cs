using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    LevelController levelController;
    [SerializeField] Transform gunArm;
    WeaponControllerScript activeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    public void OnEquipFirst(InputValue value)
    {
        Debug.Log("Check");
        if (value.isPressed)
        {
           if(levelController.retrieveInventoryElement(0) != null)
            {
                activeWeapon = levelController.retrieveInventoryElement(0).getObject();
                activeWeapon.gameObject.transform.position = gunArm.gameObject.transform.position;
                activeWeapon.gameObject.transform.SetParent(gunArm);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Shoot()
    {
        //When LMB shoot weapon. Mandatory message to gonfen: you can do it boyfen believe in you! :)
    }
}
