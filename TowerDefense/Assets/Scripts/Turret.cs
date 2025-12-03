using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();


    public GameObject bulletPrefab;
    public Transform bulletPosition;
    public float attackRate = 0.5f;
    private float nextAttackTime;

    private Transform head;

    private void Start()
    {
        head = transform.Find("Head");
    }
    private void Update()
    {
        DirectionControl();
        Attack();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyList.Remove(other.gameObject);
        }
    }

    private void Attack()
    {
        if (enemyList == null || enemyList.Count == 0) return;


        if (Time.time > nextAttackTime)
        {
            Transform target = GetTarget();
            if (target != null)
            {
                GameObject go = GameObject.Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
                go.GetComponent<Bullet>().SetTarget(target);
                nextAttackTime = Time.time + attackRate;
            }

        }
    }

    public Transform GetTarget()
    {
        List<int> indexList = new List<int>();
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null || enemyList[i].Equals(null))
            {
                indexList.Add(i);
            }
        }
        for (int i = indexList.Count - 1; i >= 0; i--)
        {
            enemyList.RemoveAt(indexList[i]);
        }
        if (enemyList != null && enemyList.Count != 0)
        {
            return enemyList[0].transform;
        }
        return null;
    }
    private void DirectionControl()
    {
        GameObject target = null;
        if (enemyList != null && enemyList.Count > 0)
        {
            target = enemyList[0];
        }
        if (target == null) return;

        Vector3 targetPosition = target.transform.position;
        targetPosition.y = head.position.y;
        head.LookAt(targetPosition);
    }
}