using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public Transform startPoint;
    public List<Wave> waveList;

    private int enemyCount = 0;

    private void Awake()//����ģʽ
    {
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()//��ʼЭ��
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()//Э�����ɵ���
    {
        foreach (Wave wave in waveList)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, transform.position, Quaternion.identity);
                enemyCount++;
                if (i != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while(enemyCount > 0)
            {
                yield return 0;
            } 
        }
        yield return null;
    }

    public void DecreaseEnemyCount()
    {
        if(enemyCount >0)
        { 
            enemyCount--;
        }
        
    }

}
