using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piercer1 : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] private Transform PierceMuzzle;

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
                if (Physics.Raycast(PierceMuzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                }
                gunData.currentEnergy-=50;
                timeSinceLastShot = 0;
                //OnGunShot();
            }
        }

    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(PierceMuzzle.position, PierceMuzzle.forward);
    }

    private void onGunShot()
    {

    }
}
