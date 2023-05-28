using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucks : MonoBehaviour
{
    public float frictionCoefficient = 0.5f;
    public float frictionCoefficient2 = 0.5f;

    private SpriteRenderer _renderer;
    private Rigidbody2D rb;
    private Color pottedColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    private CircleCollider2D circleCollider2D;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector2.zero)
        {
            Vector2 frictionForce;
            if (rb.velocity.magnitude < 0.1f)
            {
                frictionForce = -rb.velocity * frictionCoefficient;
            }
            else
            {
                frictionForce = -rb.velocity.normalized * frictionCoefficient2;
            }
            rb.AddForce(frictionForce);
        }
    }

    public void HasBeenPotted()
    {
        _renderer.color = pottedColor;
    }
    public void EnableColor()
    {
        _renderer.color = Color.white;
    }
}
