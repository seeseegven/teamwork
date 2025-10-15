using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private int pointIndex = 0;

    private Vector3 targetPosition=Vector3.zero;

    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);//�õ�Ŀ��λ������
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPosition - transform.position).normalized * Time.deltaTime*speed);//����Ŀ��λ���ƶ�
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            MoveNextPoint();    
        }
    }
    private void MoveNextPoint()//�ƶ�����һ����
    {
        pointIndex++;
        if (pointIndex >= Movepoints.Instance.GetLength())
        {
            Die();
            return;
        }
        targetPosition = Movepoints.Instance.GetWaypoint(pointIndex);
    }
    void Die()//��������
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreaseEnemyCount();
    }
}
