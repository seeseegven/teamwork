using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretData
{
    public GameObject Turretlv1Prefab;
    public int lv1cost; 
    public GameObject Turretlv2Prefab;
    public int lv2cost; 
    public TurretType type;
}

public enum TurretType
{
    StandardTurret,
    MissileTurret,
    LaserTurret
}
