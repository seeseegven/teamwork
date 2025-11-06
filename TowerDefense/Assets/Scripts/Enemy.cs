using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int pointIndex = 0;
    private Vector3 targetPosition = Vector3.zero;
    public float speed = 4;
    // 转向速度（值越大转向越灵敏）
    public float rotationSpeed = 10f;

    void Start()
    {
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);
    }

    void Update()
    {
        // 计算目标方向（忽略Y轴高度差，保持在同一平面转向）
        Vector3 targetDirection = targetPosition - transform.position;
        targetDirection.y = 0; // 确保只在XZ平面转向

        if (targetDirection.magnitude > 0.1f) // 当有移动方向时才转向
        {
            // 计算目标旋转角度
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            // 平滑过渡到目标旋转
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // 朝向目标位置移动（沿自身前方向移动）
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // 到达当前路径点后切换到下一个
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
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);
    }

    void Die()
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreaseEnemyCount();
    }

    public void TakeDamage(int damage)
    {
        // 伤害处理逻辑（可后续补充）
    }
}