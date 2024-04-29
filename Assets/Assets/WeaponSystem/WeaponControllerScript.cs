using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponControllerScript : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] string weaponName;
    [SerializeField] public float rateOfFire;
    [SerializeField] public float range;
    //[SerializeField] private AudioClip _shootSound;
    private Mesh weaponMesh;
    LevelController levelController;
    private bool isEquipped = false;
    //location of the gun in playerViewport
    [SerializeField] private GameObject gunArm;
    int listIndex;
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
            listIndex = levelController.changeInventory(weaponName, range, rateOfFire, damage, gameObject.GetComponent<WeaponControllerScript>());
            if (!isEquipped)
            {
                //Destroy(gameObject);
            }
        }
    }

    public int getIndex()
    {
        return listIndex;
    }
}
