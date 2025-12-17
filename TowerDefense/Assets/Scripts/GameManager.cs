using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameEndUI EndUI;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowFail()
    {
        EnemySpawner.Instance.Stop();
        EndUI.Show("Man");
    }
    public void ShowWin()
    {
        EndUI.Show("HaHaHa HaHa");
    }
    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void OnMenuClick()
    {
        SceneManager.LoadScene(0);
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
