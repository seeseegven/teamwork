using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }

    public TurretData StandardTurretData;
    public TurretData MissileTurretData;
    public TurretData LazerTurretData;


    public TurretData selectedTurretData;

    public TextMeshProUGUI moneyText;
    private int money = 1000;
    
    private void Awake()
    {
        Instance = this;
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
