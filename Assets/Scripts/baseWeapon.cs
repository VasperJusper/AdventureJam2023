using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class baseWeapon : MonoBehaviour
{
    public Transform muzzle;

    public TMP_Text currentAmmoText, magSizeText;
    public weaponSO weaponSO;
    public GameObject bulletPrefab;

    public float currentAmmo, reloadTime, nextFire, fireRate;

    void Start()
    {
        currentAmmo = weaponSO.ammo;
        reloadTime = weaponSO.reloadTime;
        fireRate = weaponSO.fireRate;

    }

    private void Awake()
    {
        magSizeText.text = weaponSO.magSize.ToString();
        currentAmmoText.text = currentAmmo.ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) & nextFire < Time.time & currentAmmo > 0)
        {
            nextFire = Time.time + fireRate;
            var bulletPrefab1 = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.rotation);
            bulletPrefab1.GetComponent<Rigidbody2D>().velocity = muzzle.right * weaponSO.bulletSpeed;
            currentAmmo -= 1f;
            magSizeText.text = weaponSO.magSize.ToString();
            currentAmmoText.text = currentAmmo.ToString();
        }

        if (currentAmmo < 1f || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(weaponSO.reloadTime);
        currentAmmo = weaponSO.magSize;
    }
}
