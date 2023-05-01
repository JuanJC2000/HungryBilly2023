using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWonScreen : MonoBehaviour
{
    public Text timeTaken;

    /// <summary>
    /// SetUp sets our screen to active and returns a float in seconds for time taken. Is called inside Game Manager.
    /// </summary>
    /// <param name="score"></param>
    public void Setup(float score)
    {
        gameObject.SetActive(true);
        timeTaken.text = score.ToString() +  "seconds";
    }
}
