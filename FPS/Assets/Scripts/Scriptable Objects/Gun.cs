using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun")]
public class Gun : ScriptableObject
{
    public GameObject model;
    public float dmg;
    public float strength;
    public int maxAmmo;
    public int maxClip;
}
