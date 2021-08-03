using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;
    public Gun startingGun;
    Gun _equippedGun;

    void Start()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }
     void EquipGun(Gun gunToEquip)
    {
        if (_equippedGun != null)
       {
           Destroy(_equippedGun.gameObject);
       }
       _equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
       _equippedGun.transform.parent = weaponHold;

    }

     public void Shoot()
     {
         if (_equippedGun != null)
         {
             _equippedGun.Shoot();
         }
     }
}

