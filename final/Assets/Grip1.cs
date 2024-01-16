using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip1 : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] private Transform gripMuzzle;
  //  private HealthControl healthControl;

    float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        GameObject player = GameObject.FindWithTag("Player");
    //    healthControl = player.GetComponent<HealthControl>();
    }

    private bool CanShoot() => timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Shoot()
    {
        if (gunData.currentEnergy > 0)
        {
            if (CanShoot())
            {
                if(Physics.Raycast(gripMuzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                }
                //healthControl.energy -=10;
                timeSinceLastShot = 0;
                //OnGunShot();
            }
        }

    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(gripMuzzle.position, gripMuzzle.forward);
    }

    private void onGunShot()
    {
        
    }
}
