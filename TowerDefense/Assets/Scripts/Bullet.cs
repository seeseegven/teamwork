using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 子弹伤害
    public int damage = 50;
    // 子弹速度
    public float speed = 50;

    public GameObject bulletExplosionPrefab;

    private Transform target;

    private void Update()
    {
        if (target == null) 
        {
            Dead();
            return; 
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 1)
        {
            Dead();
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
    private void Dead()
    {
        Destroy(this.gameObject);
        GameObject go = GameObject.Instantiate(bulletExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(go, 1);

        if (target != null)
        {
            go.transform.parent = target.transform;
        }
    }
}
