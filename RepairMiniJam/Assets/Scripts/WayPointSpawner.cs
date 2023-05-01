using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSpawner : MonoBehaviour
{
    public GameObject[] waypointsPrefabs;
    public Transform[] waypointsPositions;

    private Transform currentWaypoint;

    void Start()
    {
        int randomIndex = Random.Range(0, waypointsPrefabs.Length);
        GameObject selectedWaypoint = waypointsPrefabs[randomIndex];
        Transform selectedPosition = waypointsPositions[randomIndex];

        currentWaypoint = Instantiate(selectedWaypoint, selectedPosition.position, selectedPosition.rotation, transform).transform;
        currentWaypoint.localScale = selectedPosition.localScale;
    }
}