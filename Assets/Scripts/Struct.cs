
//public struct PlayerPower
//{
//    int MaxHealth; //��ũ�� ü�� 10% ����(�ִ� ��ũ 3)
//    int Recovery; // ��ũ�� �ǰ� ����� 1 ����(�ִ� ��ũ 3)
//    int Might; // ��ũ�� ���ݷ� 5% ����(�ִ� ��ũ 5)
//    int Armor; //��ũ�� �ǰ� ����� 1 ����(�ִ� ��ũ 3)
//    int CoolDown; // ��ũ�� ��Ÿ�� 2.5% ����(�ִ� ��ũ 2)
//    int Area; //  ��ũ�� ���� 5% ����(�ִ� ��ũ 2)
//    int Speed; //��ũ�� ����ü �ӵ� 10% ����(�ִ� ��ũ 2)
//    int Duration;//  ��ũ�� ���ӷ� 15% ����(�ִ� ��ũ 2)
//    int Amount; // ����ü ���� +1(�ִ� ��ũ 1)
//    int MoveSpeed;// ��ũ�� �̵��ӵ� 5% ����(�ִ� ��ũ 2)
//    int Magnet; // ��ũ�� ȹ��ݰ� 25% ����(�ִ� ��ũ 2)
//    int Luck; //��ũ�� ��� ��ġ 10% ����(�ִ� ��ũ 3)
//    int Growth;//��ũ�� ����ġ ȹ�� 3% ����(�ִ� ��ũ 5)
//    int Greed; //��ũ�� ��� ȹ�� 5% ����(�ִ� ��ũ 5)
//}

//struct PlayerStat
//{
//    int HP;
//    int MoveSpeed;
//    int EXP;
//    int Rank;
//}//Player ĳ���� �⺻ ���� 

struct MonsterStat
{
    int HP;
    int MoveSpeed;
    int ATK;
}

struct AblilityStat
{
    int ATK; //���ݷ�
    int Amount; //����ü 
    int Limit; // ����ü ����
    int CoolTime; //��Ÿ��
    int penetration; //����
    int DurationTime; //���ӽð�
    int Critical; //ġ��Ÿ ������ 2��
}