using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public Transform startPoint;
    public List<Wave> waveList;

    private int enemyCount = 0;

    private void Awake()//单例模式
    {
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()//开始协程
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()//协程生成敌人
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
