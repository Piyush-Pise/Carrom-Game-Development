using System.Collections.Generic;
using UnityEngine;

public class Pockets : MonoBehaviour
{
    public NewGameManager gameManager;
    private const float MaxPottedDistance = 0.0885f;
    private const string StrikerTag = "Striker";

    private void OnTriggerEnter2D(Collider2D other) => CheckAndRegister(other);

    private void OnTriggerStay2D(Collider2D other) => CheckAndRegister(other);

    private void CheckAndRegister(Collider2D other)
    {
        if (!ShouldRegisterPuck(other))
            return;

        RegisterPuck(other);
    }

    private bool ShouldRegisterPuck(Collider2D other)
    {
        if (gameManager.State != gameManager.FreeState)
            return false;

        Rigidbody2D rigidbody = other.GetComponent<Rigidbody2D>();
        if (rigidbody == null)
            return false;

        float distance = Vector3.Distance(other.transform.position, transform.position);
        return distance <= MaxPottedDistance;
    }

    private void RegisterPuck(Collider2D other)
    {
        string puckName = other.name;

        if (IsPuckAlreadyRegistered(puckName))
            return;

        Rigidbody2D rigidbody = other.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.zero;
        other.GetComponent<CircleCollider2D>().enabled = false;
        other.GetComponent<Pucks>().HasBeenPotted();
        gameManager.PottedPucks.Add(other.gameObject);

        if (other.CompareTag(StrikerTag))
        {
            HandleStrikerFoul();
        }
    }

    private bool IsPuckAlreadyRegistered(string puckName)
    {
        return gameManager.PottedPucks.Exists(puck => puck.name == puckName);
    }

    private void HandleStrikerFoul()
    {
        gameManager._foul = true;
        Handheld.Vibrate();
    }
}
