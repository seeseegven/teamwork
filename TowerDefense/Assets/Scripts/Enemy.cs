using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int pointIndex = 0;
    private Vector3 targetPosition = Vector3.zero;
    public float speed = 4f;
    public int hp = 100;

    void Start()
    {
        // 初始目标为第一个路径点
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);
        // 初始朝向第一个目标点（无延迟）
        ForceRotateToTarget(targetPosition);
    }

    void Update()
    {
        // 始终沿当前朝向移动（无停顿）
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

        // 到达当前目标点时，立即切换下一个目标并转向
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
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
        // 获取下一个目标点
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);
        // 到达当前点后，立即强制转向下一个目标（无平滑过渡，瞬间完成）
        ForceRotateToTarget(targetPosition);
    }

    // 强制转向目标点（瞬间完成，无延迟）
    private void ForceRotateToTarget(Vector3 target)
    {
        Vector3 targetDirection = target - transform.position;
        targetDirection.y = 0; // 忽略Y轴，保持水平转向
        if (targetDirection.magnitude > 0.01f) // 避免目标点过近导致的旋转异常
        {
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreaseEnemyCount();
        GameObject go = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(go, 1);
    }

    public void TakeDamage(int damage)
    {
        hp-=damage;
        if (hp <= 0)
        {
            Die();
        }
    }
}
