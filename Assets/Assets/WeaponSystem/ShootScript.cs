using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    LevelController levelController;
    [SerializeField] Transform gunArm;
    [SerializeField] Transform gunStore;
    WeaponControllerScript activeWeapon;

    [SerializeField] private LayerMask _layersToShoot = -1;
    [SerializeField] private Camera _camera;

    [SerializeField] private ParticleSystem _impactParticle;
   
    [SerializeField] private AudioClip _shootSound;

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
            
           else
            {
                activeWeapon.gameObject.transform.SetParent(null);
                activeWeapon = levelController.retrieveInventoryElement(0).getObject();
                activeWeapon.gameObject.transform.position = gunStore.gameObject.transform.position;
            }
        }
    }

    public void OnEquipSecond(InputValue value)
    {
        Debug.Log("Check");
        if (value.isPressed)
        {
            if (levelController.retrieveInventoryElement(1) != null)
            {
                activeWeapon = levelController.retrieveInventoryElement(1).getObject();
                activeWeapon.gameObject.transform.position = gunArm.gameObject.transform.position;
                activeWeapon.gameObject.transform.SetParent(gunArm);
            }
            else 
            {
                activeWeapon.gameObject.transform.SetParent(null);
                activeWeapon = levelController.retrieveInventoryElement(1).getObject();
                activeWeapon.gameObject.transform.position = gunStore.gameObject.transform.position;
            }
        }
    }

    public void OnEquipThird(InputValue value)
    {
        Debug.Log("Check");
        if (value.isPressed)
        {
            if (levelController.retrieveInventoryElement(2) != null)
            {
                activeWeapon = levelController.retrieveInventoryElement(2).getObject();
                activeWeapon.gameObject.transform.position = gunArm.gameObject.transform.position;
                activeWeapon.gameObject.transform.SetParent(gunArm);
            }
            else 
            {
                activeWeapon.gameObject.transform.SetParent(null);
                activeWeapon = levelController.retrieveInventoryElement(2).getObject();
                activeWeapon.gameObject.transform.position = gunStore.gameObject.transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnShoot(InputValue value)
    {
        //When LMB shoot weapon
         if (value.isPressed)
        {
            Debug.Log("Shoot");
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 rayStartPos = _camera.transform.position;
        Vector3 rayDirection = _camera.transform.forward;
        Debug.DrawRay(rayStartPos, rayDirection * levelController.retrieveInventoryElement(activeWeapon.getIndex()).GetRange(), Color.yellow, 1);
        RaycastHit hitInfo;
        if (Physics.Raycast(rayStartPos, rayDirection, out hitInfo, levelController.retrieveInventoryElement(activeWeapon.getIndex()).GetRange(), _layersToShoot))
        {

            if (_impactParticle != null)
            {
                Instantiate(_impactParticle, hitInfo.point, Quaternion.identity);
            }
            if (_shootSound != null)
            {

                AudioSource newSound = AudioManager.PlayClip2D(_shootSound, 1);
                
               // Destroy(newSound.gameObject, newSound.clip.length);
            }
            ShootAble shootableObject =
                hitInfo.transform.GetComponent<ShootAble>();
            if (shootableObject != null)
            {
                shootableObject.Shoot(levelController.retrieveInventoryElement(activeWeapon.getIndex()).GetDamage());
            }
        }
    }
}
