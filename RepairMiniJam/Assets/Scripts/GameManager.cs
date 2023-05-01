using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Using static instane to store a reference to this game manager

    public GameOverScreen GameOverScreen;
    public GameWonScreen GameWonScreen;

    public UnityEvent OnWin;
    public UnityEvent OnLose;

    /// <summary>
    /// Prevents multiple Game Managers from being active at one time
    /// </summary>
    private void Awake()
    {
        Time.timeScale = 1.0f;
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

    public void WinGame(float timeTaken) //Invoke event
    {
        Debug.Log("You have won!");
        Debug.Log("Time Taken " + timeTaken);
        GameWonScreen.Setup(timeTaken);
        OnWin?.Invoke();
        Time.timeScale = 0f;
    }

    public void LoseGame() //Invoke event
    {
        
        Debug.Log("You Crashed!");
        GameOverScreen.Setup();
        OnLose?.Invoke();
        Time.timeScale = 0f;
       // ReloadCurrentScene();
    }

    public void WinGameTest() //Invoke event
    {
        Debug.Log("You have won!");
        
        OnWin?.Invoke();
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
