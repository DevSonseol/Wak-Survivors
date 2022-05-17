using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Powers
{
    Might, Armor, MaxHealth, Recovery, CoolDown, Area, Speed, Duration, Amount, MoveSpeed, Magnet, Luck, Growth, Greed
}

[System.Serializable]
public struct PlayerPower//�Ŀ� ī��Ʈ �뵵
{
    public int Might; // ��ũ�� ���ݷ� 5% ����(�ִ� ��ũ 5)
    public int Armor; //��ũ�� �ǰ� ����� 1 ����(�ִ� ��ũ 3)
    public int MaxHealth; //��ũ�� ü�� 10% ����(�ִ� ��ũ 3)
    public int Recovery; // ��ũ�� 0.1 ����(�ִ� ��ũ 3)
    public int CoolDown; // ��ũ�� ��Ÿ�� 2.5% ����(�ִ� ��ũ 2)
    public int Area; //  ��ũ�� ���� 5% ����(�ִ� ��ũ 2)
    public int Speed; //��ũ�� ����ü �ӵ� 10% ����(�ִ� ��ũ 2)
    public int Duration;//  ��ũ�� ���ӷ� 15% ����(�ִ� ��ũ 2)
    public int Amount; // ����ü ���� +1(�ִ� ��ũ 1)
    public int MoveSpeed;// ��ũ�� �̵��ӵ� 5% ����(�ִ� ��ũ 2)
    public int Magnet; // ��ũ�� ȹ��ݰ� 25% ����(�ִ� ��ũ 2)
    public int Luck; //��ũ�� ��� ��ġ 10% ����(�ִ� ��ũ 3)
    public int Growth;//��ũ�� ����ġ ȹ�� 3% ����(�ִ� ��ũ 5)
    public int Greed; //��ũ�� ��� ȹ�� 5% ����(�ִ� ��ũ 5)
}

[System.Serializable]
public struct PlayerStat//�⺻ ���� + �Ŀ��� ���� �÷��� ����
{
    public float Might; // ��ũ�� ���ݷ� 5% ����(�ִ� ��ũ 5)
    public float Armor; //��ũ�� �ǰ� ����� 1 ����(�ִ� ��ũ 3)
    public float MaxHealth; //��ũ�� ü�� 10% ����(�ִ� ��ũ 3)
    public float Recovery; // ��ũ�� �ǰ� ����� 1 ����(�ִ� ��ũ 3)
    public float CoolDown; // ��ũ�� ��Ÿ�� 2.5% ����(�ִ� ��ũ 2)
    public float Area; //  ��ũ�� ���� 5% ����(�ִ� ��ũ 2)
    public float Speed; //��ũ�� ����ü �ӵ� 10% ����(�ִ� ��ũ 2)
    public float Duration;//  ��ũ�� ���ӷ� 15% ����(�ִ� ��ũ 2)
    public float Amount; // ����ü ���� +1(�ִ� ��ũ 1)
    public float MoveSpeed;// ��ũ�� �̵��ӵ� 5% ����(�ִ� ��ũ 2)
    public float Magnet; // ��ũ�� ȹ��ݰ� 25% ����(�ִ� ��ũ 2)
    public float Luck; //��ũ�� ��� ��ġ 10% ����(�ִ� ��ũ 3)
    public float Growth;//��ũ�� ����ġ ȹ�� 3% ����(�ִ� ��ũ 5)
    public float Greed; //��ũ�� ��� ȹ�� 5% ����(�ִ� ��ũ 5)
}

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameSystem>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("GameSystem");
                    instance = instanceContainer.AddComponent<GameSystem>();
                }
            }

            return instance; 
        }

    }

    private static GameSystem instance;

    [SerializeField]
    private PlayerCharacter character = PlayerCharacter.Wak;

    [SerializeField]
    private PlayerPower playerPowerData;

    [SerializeField]
    private PlayerStat playerStatData;

    public PlayerStat PlayerStatData
    {
        get { return playerStatData; }
    }
    public void SetPlayerStatData(PlayerStat _stat)
    {
        playerStatData = _stat;
    }

    public void SetCharacter(PlayerCharacter ch)
    {
        character = ch;
    }

    public PlayerPower PlayerPowerData
    {
        get { return playerPowerData; }
    }

    public void SetPlayerPowerLevel(Powers power,int level)
    {
        switch (power)
        {
            case Powers.Might:
                playerPowerData.Might = level;
                break;
            case Powers.Armor:
                playerPowerData.Armor = level;
                break;
            case Powers.MaxHealth:
                playerPowerData.MaxHealth = level;
                break;
            case Powers.Recovery:
                playerPowerData.Recovery = level;
                break;
            case Powers.CoolDown:
                playerPowerData.CoolDown = level;
                break;
            case Powers.Area:
                playerPowerData.Area = level;
                break;
            case Powers.Speed:
                playerPowerData.Speed = level;
                break;
            case Powers.Duration:
                playerPowerData.Duration = level;
                break;
            case Powers.Amount:
                playerPowerData.Amount = level;
                break;
            case Powers.MoveSpeed:
                playerPowerData.MoveSpeed = level;
                break;
            case Powers.Magnet:
                playerPowerData.Magnet = level;
                break;
            case Powers.Luck:
                playerPowerData.Luck = level;
                break;
            case Powers.Growth:
                playerPowerData.Growth = level;
                break;
            case Powers.Greed:
                playerPowerData.Greed = level;
                break;
        }
    }

    public void ResetPowerData()
    {
        playerPowerData.Might = 0;
        playerPowerData.Armor = 0;
        playerPowerData.MaxHealth = 0;
        playerPowerData.Recovery = 0;
        playerPowerData.CoolDown = 0;
        playerPowerData.Area = 0;
        playerPowerData.Speed = 0;
        playerPowerData.Duration = 0;
        playerPowerData.Amount = 0;
        playerPowerData.MoveSpeed = 0;
        playerPowerData.Magnet = 0;
        playerPowerData.Luck = 0;
        playerPowerData.Growth = 0;
        playerPowerData.Greed = 0;
    }

    private int coin = 50000;
    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }

    private int cost = 0;
    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }


    private int lvUpCount;
    public int LvUpCount 
    {
        get { return lvUpCount; }
        set { lvUpCount = value; }
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public PlayerPower GetGameData()
    {
        return new PlayerPower()
        {
            Might = playerPowerData.Might,
            Armor =  playerPowerData.Armor,
            MaxHealth = playerPowerData.MaxHealth,
            Recovery = playerPowerData.Recovery,
            CoolDown = playerPowerData.CoolDown,
            Area = playerPowerData.Area,
            Speed = playerPowerData.Speed,
            Duration = playerPowerData.Duration,
            Amount = playerPowerData.Amount,
            MoveSpeed = playerPowerData.MoveSpeed,
            Magnet = playerPowerData.Magnet,
            Luck = playerPowerData.Luck,
            Growth = playerPowerData.Growth,
            Greed = playerPowerData.Greed,
        };
    }

}
