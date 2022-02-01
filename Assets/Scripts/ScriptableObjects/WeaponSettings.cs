using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/weaponSettings",order =1)]
public class WeaponSettings : ScriptableObject
{
    [SerializeField] private float range;
    public float Range
    {
        get
        {
            return range;
        }
    }
    [SerializeField] private float fireRate;

    public float FireRate
    {
        get
        {
            return fireRate;
        }
    }
    [SerializeField] private int maxAmmo;
    public int MaxAmmo
    {
        get
        {
            return maxAmmo;
        }
    }
    [SerializeField] private int reloadTime;
    public float ReloadTime
    {
        get
        {
            return reloadTime;
        }
    }
    [SerializeField] private bool isPistol;
    public bool IsPistol
    {
        get
        {
            return isPistol;
        }
    }

}
