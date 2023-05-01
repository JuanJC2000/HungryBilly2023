using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointSpawner : MonoBehaviour
{
    public GameObject[] waypointsPrefabs; //Holds the physical game objects
    public Transform[] waypointsPositions; // Holds the physical game positions

    private Transform currentWaypoint; //Current Index

    void Start()
    {
        int randomIndex = Random.Range(0, waypointsPrefabs.Length); //Select a random index from the length array
        GameObject selectedWaypoint = waypointsPrefabs[randomIndex]; //From the selected index, get the prefab and position
        Transform selectedPosition = waypointsPositions[randomIndex];

        // Instantiate new instance of waypoint prefab using parented transform position. To ensure proper placement, we set the local scale to match the local scale of the selected transform.
        currentWaypoint = Instantiate(selectedWaypoint, selectedPosition.position, selectedPosition.rotation, transform).transform; 
        currentWaypoint.localScale = selectedPosition.localScale;
    }
}