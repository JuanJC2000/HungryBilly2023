using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWonScreen : MonoBehaviour
{
    public Text timeTaken;

    public void Setup(float score)
    {
        gameObject.SetActive(true);
        timeTaken.text = score.ToString() +  "seconds";
    }
}
