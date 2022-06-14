using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    Whip, MagicWand, Knife, Axe, Cross, Bible, FireWand, Garlic, SantaWater, RuneTracer, LightingRing, Pentagram, Gun , Peachone
}


public class WeaponSystem : MonoBehaviour
{
    public static WeaponSystem Instance;

    [SerializeField]
    private List<Weapon> weaponList = new List<Weapon>();

    [SerializeField]
    private List<Weapon> playerWeaponList = new List<Weapon>();


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
