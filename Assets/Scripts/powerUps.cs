using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class powerUps : ScriptableObject
{
    public string upgradeName, description;

    public abstract void Apply(GameObject weapon);
}
