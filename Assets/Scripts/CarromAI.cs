using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarromAI : MonoBehaviour
{
    public NewGameManager gm;
    public List<Transform> WhitePucks = new List<Transform>();
    public Transform[] Pockets;
    public Vector2 _AIStrikerPosition;
    public Vector2 _AIStrikerDirection;
    public float _AINewScale;

    // Calculate a possible position for the AI striker
    public void CalculatePossiblePosition()
    {
        // Check for valid intersections between pockets and pucks
        if (CheckValidIntersection())
        {
            Debug.Log("Valid possible position calculated");
            return;
        }

        // Generate random values for the striker position and direction
        float newX = Random.Range(gm.StrikerMovRangeX.x, gm.StrikerMovRangeX.y);
        _AIStrikerPosition = new Vector2(newX, -gm.StrikerTransY);
        Vector2 temp = Random.insideUnitCircle;
        if (WhitePucks.Count > 0)
        {
            temp = WhitePucks[Random.Range(0, WhitePucks.Count)].position;
        }
        _AIStrikerDirection = (temp - _AIStrikerPosition).normalized;
        _AINewScale = Random.Range(0.9f, 1.2f);
    }

    // Check for valid intersections between pockets and pucks
    private bool CheckValidIntersection()
    {
        foreach (Transform puck in WhitePucks)
        {
            foreach (Transform pocket in Pockets)
            {
                if (Intersection(pocket.position, puck.position))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // Check if an intersection occurs between a pocket and a puck
    private bool Intersection(Vector2 pocket, Vector2 puck)
    {
        float intersectionX = (((-gm.StrikerTransY - puck.y) * (pocket.x - puck.x)) / (pocket.y - puck.y)) + puck.x;
        bool isIntersectionInRange = gm.StrikerMovRangeX.x <= intersectionX && intersectionX <= gm.StrikerMovRangeX.y;
        if (!isIntersectionInRange)
        {
            return false;
        }

        _AIStrikerPosition = new Vector2(intersectionX, -gm.StrikerTransY);
        _AIStrikerDirection = puck - _AIStrikerPosition;
        _AINewScale = (_AIStrikerDirection.magnitude > 1f) ? Random.Range(1f, 1.2f) : Random.Range(0.8f, 1f);
        _AIStrikerDirection = _AIStrikerDirection.normalized;
        Vector2 newVector = (pocket - _AIStrikerPosition).normalized;

        return Vector2.Dot(newVector, _AIStrikerDirection) > 0f;
    }
}
