﻿using UnityEngine;
/// <summary>
/// Handles Bubble physics and detects Bullet collision. This script is attached to Bubble.
/// </summary>
public class BabbleMove : MonoBehaviour
{
    public Rigidbody2D _rigid;          // Rigidbody of this gameObject.
    [Tooltip("This Vector2 is Impulse force used when Bubble is spawned in Scene.")]
    public Vector2 startForce;          // Start force for Bubbles.
    [Tooltip("Prefab of a next lower ranked Bubble. Leave it Empty if there are non.")]
    public GameObject nextBubble;       // Next smaller Bubble for spawning.
    private bool hasCollided = true;    // Allows only 1 collision to be made.
    [Header("Y-axis velocity Settings")]
    [Tooltip("Minimum allowed Y velocity. If the velocity of Y-axis is below this number, then the next time when it bounces off the floor it will receive additional boost declared in 'Boost' field.")]
    public float min;                   // Provides minimum allowed velocity of Y-axis.
    [Tooltip("Maximum allowed Y velocity. If the velocity of Y-axis is above this number, then Force will be applied until it goes below from the value of this field.")]
    public float max;                   // Provides maximum allowed velocity of Y-axis.
    [Header("Bubble speed Settings")]
    public float minSpeed;              // Provides data of minimum allowed speed for this Bubble.
    public float normalSpeed, maxSpeed; // Provides data of normal and maximum speed for this Bubble.
    public float boost;                 // Provides boost for Y-axis velocity. If Y-axis force has decreased.

    void Start()
    {
        _rigid.AddForce(startForce, ForceMode2D.Impulse);   // Adds initial force.
    }

    private void FixedUpdate()
    {
        Xaxis();            // Physics for X axis.
        Yaxis();            // Physics for Y axis.
    }

    private void Xaxis()
    {
        if (_rigid.velocity.x >= 0 && (_rigid.velocity.x < minSpeed || _rigid.velocity.x > maxSpeed)) // Conditions for fixing positive X velocity.
        {
            _rigid.velocity = new Vector2(normalSpeed, _rigid.velocity.y);    // Sets new positive X velocity.
        }
        else if (_rigid.velocity.x <= 0 && (_rigid.velocity.x > -minSpeed || _rigid.velocity.x < -maxSpeed))  // Conditions for fixing negative X velocity.
        {
            _rigid.velocity = new Vector2(-normalSpeed, _rigid.velocity.y);   // Sets new negative X velocity.
        }
    }

    private void Yaxis()
    {
        if(_rigid.velocity.y < -max)     // Condition for removing any extra force added to Bubble.
        {
            _rigid.AddForce(new Vector2(0, 70), ForceMode2D.Force); // Slow down this gameObject by additing positive force.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  // This is used for Bullet detection.
    {
        string tag = collision.gameObject.tag;
        string name = collision.gameObject.name;

        switch (tag)
        {
            case "Weapon":
                if (hasCollided)    // This makes sure that only 1 Collision is made, instead of multiple.
                {
                    GetComponent<PowerUpSystem>().RandomPopups(transform.position); // Gets script Component on this gameObject, calls RandomPopups(), which spawns Random Power-Up.
                    SoundCtrl.instance.BubbleDestroyed();                           // Played when Bubble is Destroyed.
                    Split();                                                        // Destroys the Bubble and spawns 2 more.
                    collision.gameObject.SetActive(false);                          // Hides the Bullet that hit this Bubble.
                    hasCollided = false;                                            // Sets false which disable being hit more times.

                    if (name.Contains("Bubble S"))
                    {
                        GameCtrl.instance.UpdateScore(Random.Range(100, 250));  // Updates game Score within given Range.
                    }
                    else if (name.Contains("Bubble M"))
                    {
                        GameCtrl.instance.UpdateScore(Random.Range(350, 500));  // Updates game Score within given Range.
                    }
                }
                break;
            case "Meter":
                if (_rigid.velocity.y < min) // Condition for applying aditional force to Bubble.
                {
                    if (_rigid.velocity.x < 0 )
                    {
                        _rigid.velocity = new Vector2(-normalSpeed, boost);    // Increases velocity by adding force. Based on start distance.
                    }
                    else if (_rigid.velocity.x >= 0)
                    {
                        _rigid.velocity = new Vector2(normalSpeed, boost);    // Increases velocity by adding force. Based on start distance.
                    }
                }
                break;
        }
    }

    public void Split()     // Creates 2 small ballons.
    {
        if (nextBubble != null)     // If there are nextBubbles. 
        {
            GameObject Bubble1 = Instantiate(nextBubble, _rigid.position + Vector2.up / 1f, Quaternion.identity);   // Instantiates Bubble with specific position.
            Bubble1.GetComponent<BabbleMove>().startForce = new Vector2(-2.2f, 5f);                                 // Sets unique startForce. 
            GameObject Bubble2 = Instantiate(nextBubble, _rigid.position + Vector2.up / 1f, Quaternion.identity);   // Instantiates Bubble.
            Bubble2.GetComponent<BabbleMove>().startForce = new Vector2(2.2f, 5f);                                  // Sets unique startForce.
        }
        Destroy(gameObject);        // Destroy the current Bubble.
    }
}
