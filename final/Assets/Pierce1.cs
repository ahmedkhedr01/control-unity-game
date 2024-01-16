using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piercer1 : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] private Transform PierceMuzzle;

    float timeSinceLastShot;
    public GameObject player;
    private HealthControl healthControl;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        healthControl = player.GetComponent<HealthControl>();
    }

    private bool CanShoot() => timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Shoot()
    {
        if (healthControl.energy > 0)
        {
            if (CanShoot())
            {
                // Get the ray from the mouse cursor position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Create a new Vector3 with the modified x component
                ray.origin = new Vector3(ray.origin.x, ray.origin.y, ray.origin.z + 1.0f);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                    if (hitInfo.transform.name == "character")
                    {
                        hitInfo.transform.GetComponent<EnemyController>().DecreaseHealth(60);
                    }
                }
                healthControl.energy -= 50;
                timeSinceLastShot = 0;
                //OnGunShot();
            }
        }

    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    private void onGunShot()
    {

    }
}
