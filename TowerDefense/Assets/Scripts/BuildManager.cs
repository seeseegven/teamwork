using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }

    public TurretData StandardTurretData;
    public TurretData MissileTurretData;
    public TurretData LazerTurretData;

    public TurretData SelectedTurretData;

    public TextMeshProUGUI moneyText;

    private int money = 1000;

    private void Awake()
    {
        Instance = this;
    }
    public void OnStandardSelected(bool isOn)//¼à²âÅÚËþµÄÑ¡Ôñ
    {
        if (isOn)
        {
            SelectedTurretData = StandardTurretData;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = MissileTurretData;
        }
    }
    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            SelectedTurretData = LazerTurretData;
        }
    }

    public bool IsEnough(int need)
    {
        return money >= need;
    }
    
    public void ChangeMoney(int value)
    {
        this.money += value;
        moneyText.text = money.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}