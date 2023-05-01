using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    
    /// <summary>
    /// Enables and disables our screen which we call in Game Manager.
    /// </summary>
    public void Setup()
    {
        gameObject.SetActive(true);
    }
}
