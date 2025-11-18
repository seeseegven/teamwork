using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretData
{
    public GameObject turretPrefab;
    public int cost; 
    public GameObject turretUpgradePrefab;
    public int costUpgraded; 
    public TurretType type;
}

public enum TurretType
{
    StandardTurret,
    MissileTurret,
    LaserTurret
}