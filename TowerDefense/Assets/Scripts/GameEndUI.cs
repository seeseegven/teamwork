using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndUI : MonoBehaviour
{
    private Animator animator;
    public TextMeshProUGUI message;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Show(string message)
    {
        animator.SetTrigger("End");
    }
    public void RestartSelected() 
    {
        GameManager.Instance.OnRestartClick();
    }
    public void MenuSelected() 
    {
        GameManager.Instance.OnMenuClick();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
