using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TurretData StandardTurretData;
    public TurretData MissileTurretData;
    public TurretData LazerTurretData;

    public TextMeshProUGUI moneyText;
    private int money = 1000;
    
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
