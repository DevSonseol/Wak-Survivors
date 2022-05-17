using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
    public static IngameUIManager Instance;


    [SerializeField]
    private WeaponUI weaponUI;
    public WeaponUI WeaponUI { get { return weaponUI; } }

  
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
