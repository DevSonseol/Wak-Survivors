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

    public List<Weapon> WeaponList { get { return weaponList; } }


 
    public List<Weapon> playerWeaponList = new List<Weapon>();

    private void Awake()
    {
        Instance = this;

    }



    public void Add_Weapon(Weapon _weapon)
    {

        foreach(Weapon weapon in playerWeaponList)
        {
            if(weapon.weaponType == _weapon.weaponType)
            {
                weapon.LevelUp();
                return;
            }
        }

        foreach (Weapon weapon in weaponList)
        {
            if (weapon == _weapon)
            {
                var wp = Instantiate(weapon, GameObject.Find("WeaponSystem").transform);
                playerWeaponList.Add(wp);
                wp.gameObject.SetActive(true);
            }
        }

    }

}
