using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode
{
    // The position on the grid
    public Vector2Int gridPosition;

    // List of the node's neighbors
    public List<AStarNode> neighbours = new List<AStarNode>();

    // Is the node an obstacle
    public bool isObstacle = false;

    // Distance from the start point to the node
    public int gCostDistanceFromStart = 0;

    // Distance from the node to the goal
    public int hCostDistanceFromGoal = 0;

    // The total cost of movement to the grid position
    public int fCostTotal = 0;

    // The order in which it was picked
    public int pickedOrder = 0;

    // State to check if the cost has already been calculated
    bool isCostCalculated = false;

    // Constructor
    public AStarNode(Vector2Int gridPosition_)
    {
        gridPosition = gridPosition_;
    }

    public void CalculateCostsForNode(Vector2Int aiPosition, Vector2Int aiDestination)
    {
        // If we have already calculated the cost then we do not need to do it again.
        if (isCostCalculated)
            return;

        // Calculate the distance from the start point to the node
        gCostDistanceFromStart = Mathf.Abs(gridPosition.x - aiPosition.x) + Mathf.Abs(gridPosition.y - aiPosition.y);

        // Calculate the distance from the node to the goal
        hCostDistanceFromGoal = Mathf.Abs(gridPosition.x - aiDestination.x) + Mathf.Abs(gridPosition.y - aiDestination.y);

        // Calculate the total cost of movement to the grid position
        fCostTotal = gCostDistanceFromStart + hCostDistanceFromGoal;

        isCostCalculated = true;
    }

    public void Reset()
    {
        // Reset the state of the node
        isCostCalculated = false;
        pickedOrder = 0;
        gCostDistanceFromStart = 0;
        hCostDistanceFromGoal = 0;
        fCostTotal = 0;
    }
}