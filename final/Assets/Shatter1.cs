using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter1 : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] private Transform ShatterMuzzle;

    float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
    }

    private bool CanShoot() => timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Shoot()
    {
        if (gunData.currentEnergy > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(ShatterMuzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                }
                gunData.currentEnergy-=15;
                timeSinceLastShot = 0;
                //OnGunShot();
            }
        }

    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(ShatterMuzzle.position, ShatterMuzzle.forward);
    }

    private void onGunShot()
    {

    }
}
