using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Gun", menuName ="Weapon/Gun")]

public class GunData : ScriptableObject
{

    public new string name;

    public float damage;
    public float maxDistance;

    public int currentEnergy;
    public float fireRate;
    public float reloadTime;
}