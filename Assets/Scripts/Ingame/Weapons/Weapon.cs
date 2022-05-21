using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;

    [SerializeField]
    protected Sprite sprite;

    [SerializeField]
    protected Weapons weapon;

    [SerializeField]
    protected int MaxLevel = 8;

    [SerializeField]
    protected int Level = 1;

    protected bool CanEvolve = false;

    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float duratation;

    [SerializeField]
    protected float coolTime;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected int maxBulletCount = 8;
    [SerializeField]
    protected float castdelayTime = 0.05f;

    [SerializeField]
    protected GameObject magicWandBulletPrefab;

    [SerializeField]
    protected int bulletCount = 1;

    [SerializeField]
    protected bool CanCast = true;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public virtual void LevelUp() { }


}
