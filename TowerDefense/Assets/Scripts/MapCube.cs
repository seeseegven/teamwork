using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    private GameObject TurretOn;
    private TurretData TurretData;

    public GameObject BuildEffect;
    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject()==true)
        {
            return;
        }
        TurretData SelectedTD = BuildManager.Instance.SelectedTurretData;
        if (SelectedTD == null || SelectedTD.turretPrefab == null)
        {
            return;
        }
        if (TurretOn != null)
        {
            return;
        }
        BuildTurret(SelectedTD);
    }
    private void BuildTurret(TurretData turretdata)
    {
        if(BuildManager.Instance.IsEnough(turretdata.cost)==false)
        {
            return;
        }
        BuildManager.Instance.ChangeMoney(-turretdata.cost);
        TurretData = turretdata;
        TurretOn = GameObject.Instantiate(turretdata.turretPrefab, transform.position, Quaternion.identity);
        GameObject go= GameObject.Instantiate(BuildEffect, transform.position, Quaternion.identity);
        Destroy(go,2);
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
