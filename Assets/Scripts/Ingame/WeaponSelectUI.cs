using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectUI : MonoBehaviour
{

    public GameObject weaponSelectUI;

    public WeaponSelectButton[] buttons;

    List<int> weaponNumberList = new List<int>();

    public void Open_WSUI()
    {
        //WS_UI active = true;하고
        this.gameObject.SetActive(true);

        //게임 일시정지 
        Time.timeScale = 0f;

        SettingButtons();
    }

    public void Close_WSUI()
    {
        //WS_UI active = false;하고
        this.gameObject.SetActive(false);

        //게임 다시 동작시키기
        Time.timeScale = 1f;

    }
    public void SettingButtons()
    {

        CreateUnDuplicateRandom();

        //weaponsystems에서 정보 가져오고 
        buttons[0].SettingButton(WeaponSystem.Instance.WeaponList[weaponNumberList[0]]);
        buttons[1].SettingButton(WeaponSystem.Instance.WeaponList[weaponNumberList[1]]);
        buttons[2].SettingButton(WeaponSystem.Instance.WeaponList[weaponNumberList[2]]);

    }


    void CreateUnDuplicateRandom()
    {
        weaponNumberList.Clear();

        int currentNumber = Random.Range(0, WeaponSystem.Instance.WeaponList.Count);

        for (int i = 0; i < 3;)
        {
            if (weaponNumberList.Contains(currentNumber))
            {
                currentNumber = Random.Range(0, WeaponSystem.Instance.WeaponList.Count);
            }
            else
            {
                weaponNumberList.Add(currentNumber);
                i++;
            }
        }

        foreach(int num in weaponNumberList)
        {
            Debug.Log(num);
        }
    }


}
