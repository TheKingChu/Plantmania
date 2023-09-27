using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant Creation")]

public class Plant_SO : ScriptableObject
{
    public string plantName;
    public int maxHealth;

    public int defence;
    public int attack;

    public Material newMaterial;
    public Sprite sprite;
}
