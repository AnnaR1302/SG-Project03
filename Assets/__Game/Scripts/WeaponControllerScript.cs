using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponControllerScript : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] string weaponName;
    [SerializeField] float rateOfFire;
    [SerializeField] float range;
    private Mesh weaponMesh;
    LevelController levelController;
    private bool isEquipped = false;
    //location of the gun in playerViewport
    [SerializeField] private GameObject gunArm;

    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    

    // Update is called once per frame
    void Update()
    {
      
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            levelController.changeInventory(weaponName, range, rateOfFire, damage, gameObject.GetComponent<WeaponControllerScript>());
            if (!isEquipped)
            {
             //   Destroy(gameObject);
            }
        }
    }
}
