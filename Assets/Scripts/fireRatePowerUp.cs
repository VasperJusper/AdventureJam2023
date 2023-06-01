using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "powerUps/fireRateBuff", order = 1)]
public class fireRatePowerUp : powerUps
{
    public float amount;

    public override void Apply(GameObject weapon)
    {
        weapon.GetComponentInChildren<baseWeapon>().fireRate -= amount;
    }
}
