using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;

    public static PlayerData Instacne
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerData>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("PlayerData");
                    instance = instanceContainer.AddComponent<PlayerData>();
                }
            }
            return instance;
        }
    }
    [SerializeField]
    private PlayerStat stat;

    public PlayerStat Stat
    {
        get { return stat; }
    }


    private void Awake()
    {
        //stat = GameSystem.Instance.PlayerStatData;
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }


  

}
