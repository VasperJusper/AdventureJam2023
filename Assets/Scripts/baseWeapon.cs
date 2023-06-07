using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class baseWeapon : MonoBehaviour
{
    [Header("References")]
    public Transform muzzle;
    public GameObject bulletPrefab;

    [Header("UI")]
    public TMP_Text currentAmmoText, magSizeText;

    [Header("Data")]
    public weaponSO weaponSO;

    [Header("Data values")]
    public float currentAmmo, reloadTime, nextFire, fireRate;
    private bool reloading;

    void Start()
    {
        reloading = false;

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
        nextFire += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && nextFire > fireRate && currentAmmo > 0 && !reloading)
        {
            nextFire = 0;
            var bulletPrefab1 = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.rotation);
            bulletPrefab1.GetComponent<Rigidbody2D>().velocity = muzzle.right * weaponSO.bulletSpeed;

            currentAmmo -= 1f;

            magSizeText.text = weaponSO.magSize.ToString();
            currentAmmoText.text = currentAmmo.ToString();
        }

        if ((currentAmmo < 1f || Input.GetKeyDown(KeyCode.R)) && !reloading)
        {
            currentAmmoText.text = "Reloading";
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        reloading = true;

        yield return new WaitForSeconds(weaponSO.reloadTime);

        currentAmmo = weaponSO.magSize;
        currentAmmoText.text = weaponSO.ammo.ToString();

        reloading = false;
    }

    public void IncreaseFireRate()
    {
        fireRate -= 0.02f;
    }
}
