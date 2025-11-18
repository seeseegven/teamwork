using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    private GameObject turretGo;
    private TurretData turretData;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) return;
        TurretData selectedTD = BuildManager.Instance.selectedTurretData;
        if (selectedTD == null) return;

        if (turretGo != null) return;
        BuildTurret(selectedTD);
    }
    private void BuildTurret(TurretData _turretData)
    {
        //if ( BuildManager.Instance.IsEnough(_turretData.cost)==false)
        //{
            
        //}
        turretData = _turretData;
        turretGo = GameObject.Instantiate(_turretData.Turretlv1Prefab, transform.position, Quaternion.identity);
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
