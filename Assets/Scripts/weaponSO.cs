using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "gun", order = 0)]

public class weaponSO : ScriptableObject
{
    public string weaponName, description;
    public float magSize, ammo, range, damage, reloadTime, fireRate, bulletSpeed;
    public GameObject weapon;
}
