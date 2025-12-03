using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int pointIndex = 0;
    private Vector3 targetPosition = Vector3.zero;
    public float speed = 4;
    public float hp = 100f;
    public GameObject explosionPrefab;

    void Start()
    {
        // 获取第一个目标点
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);
        // 强制初始朝向第一个目标点（关键：解决初始反向问题）
        ForceFaceTarget(targetPosition);
    }

    void Update()
    {
        // 沿直线向目标点移动（移动逻辑与朝向无关，确保路径正确）
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        transform.position += moveDir * speed * Time.deltaTime;

        // 同时让敌人朝向移动方向（视觉同步，避免“侧移”或“倒移”）
        if (moveDir.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        // 到达当前点后切换下一个目标
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            MoveNextPoint();
        }
    }

    private void MoveNextPoint()
    {
        pointIndex++;
        if (pointIndex >= Movepoints.Instance.GetLength())
        {
            Die();
            return;
        }
        // 更新目标点
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);
    }

    // 强制朝向目标点（初始化时调用，确保初始方向正确）
    private void ForceFaceTarget(Vector3 target)
    {
        Vector3 targetDir = target - transform.position;
        targetDir.y = 0; // 忽略Y轴，保持水平朝向
        if (targetDir.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(targetDir);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreaseEnemyCount();
        if (explosionPrefab != null)
        {
            GameObject go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(go, 1f);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
}
