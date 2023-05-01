using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Using static instane to store a reference to this game manager

    public UnityEvent OnWin;
    public UnityEvent OnLose;

    /// <summary>
    /// Prevents multiple Game Managers from being active at one time
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void WinGame() //Invoke event
    {
        Debug.Log("You have won!");
        OnWin?.Invoke();
    }

    public void LoseGame() //Invoke event
    {
        
        Debug.Log("You Crashed!");
        OnLose?.Invoke();
    }
}
