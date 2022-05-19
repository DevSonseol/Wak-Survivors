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


    [SerializeField]
    private int coin;

    public void GainCoin(int _coin)
    {
        coin += _coin;
    }


    private void Awake()
    {
        stat = GameSystem.Instance.PlayerStatData;
    }


    public void UpdatePlayerData(Powers power, float value)
    {

        switch (power)
        {
            case Powers.Might:
                stat.Might += value;
                break;
            case Powers.Armor:
                stat.Armor += value;
                break;
            case Powers.MaxHealth:
                stat.MaxHealth += value;
                break;
            case Powers.Recovery:
                stat.Recovery += value;
                break;
            case Powers.CoolDown:
                stat.CoolDown += value;
                break;
            case Powers.Area:
                stat.Area += value;
                break;
            case Powers.Speed:
                stat.Speed += value;
                break;
            case Powers.Duration:
                stat.Duration += value;
                break;
            case Powers.Amount:
                stat.Amount += value;
                break;
            case Powers.MoveSpeed:
                stat.MoveSpeed += value;
                break;
            case Powers.Magnet:
                stat.Magnet += value;
                break;
            case Powers.Luck:
                stat.Luck += value;
                break;
            case Powers.Growth:
                stat.Growth += value;
                break;
            case Powers.Greed:
                stat.Greed += value;
                break;

        }

    }


}
