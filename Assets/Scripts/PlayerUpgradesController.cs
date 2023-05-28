using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradesController : MonoBehaviour
{
    void Start()
    {
        int Head = PlayerPrefs.GetInt("HEAD");
        int Chest = PlayerPrefs.GetInt("CHEST");
        int Arms = PlayerPrefs.GetInt("ARMS");
        int Legs = PlayerPrefs.GetInt("LEGS");

        int Movement = PlayerPrefs.GetInt("MOVEMENT");
        int Dash = PlayerPrefs.GetInt("DASH");
        int Combat = PlayerPrefs.GetInt("COMBAT");
        int Aiming = PlayerPrefs.GetInt("AIMING");
        int Gathering = PlayerPrefs.GetInt("GATHERING");

        int Pistol = PlayerPrefs.GetInt("PISTOL");
        int Shotgun = PlayerPrefs.GetInt("SHOTGUN");
        int Rifle = PlayerPrefs.GetInt("RIFLE");
        int Sword = PlayerPrefs.GetInt("SWORD");
    }
}
