using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{

    private float timeElapsed = 0f;
    private bool isTiming = false;

    private void Start()
    {
        isTiming = true;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (isTiming)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WayPoint"))
        {
            isTiming = false;
            float timeTaken = timeElapsed;
            GameManager.Instance.WinGame(timeTaken);
        }
    }
}
