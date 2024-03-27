using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DrawPathHandler : MonoBehaviour
{
    public Transform transformRootObject; // Reference to the root object containing the waypoints

    WaypointNode[] waypointNodes; // Array to store the collected waypoint nodes

    // Start is called before the first frame update
    void Start()
    {
        // This method is currently empty
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue; // Set the color of the gizmos to blue

        if (transformRootObject == null)
            return; // If the transform root object is null, exit the method

        // Get all Waypoints under the root object
        waypointNodes = transformRootObject.GetComponentsInChildren<WaypointNode>();

        // Iterate through the list of waypoint nodes
        foreach (WaypointNode waypoint in waypointNodes)
        {
            // Iterate through the list of next waypoint nodes for the current waypoint
            foreach (WaypointNode nextWayPoint in waypoint.nextWaypointNode)
            {
                if (nextWayPoint != null)
                    Gizmos.DrawLine(waypoint.transform.position, nextWayPoint.transform.position);
                    // Draw a line in the Scene view between the current waypoint and its next waypoint
            }
        }
    }
}