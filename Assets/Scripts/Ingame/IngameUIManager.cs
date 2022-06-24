using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
    public static IngameUIManager Instance;

    [SerializeField]
    private WeaponUI weaponUI;
    public WeaponUI WeaponUI { get { return weaponUI; } }

    [SerializeField]
    public WeaponSelectUI weaponSelectUI;

    public WeaponSelectUI WeaponSelectUI { get { return weaponSelectUI; } }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        InvokeRepeating("opneWS", 1f,2f);
    }

    void opneWS()
    {
        weaponSelectUI.Open_WSUI();
    }


}
