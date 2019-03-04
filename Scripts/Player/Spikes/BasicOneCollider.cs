using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles collision for BasicOne. This script is attached to BasicOne.
/// </summary>
public class BasicOneCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        string name = other.name;   // Holds the name of collided gameObject.

        switch (other.tag)  // Checks case's by other gameObjects tag.
        {
            case "Wall":
                BasicOne.IsFiredOne = false;
                break;
            case "Enemies":
                BasicOne.IsFiredOne = false;                                                // Sets false, which disables weapon grow
                SoundCtrl.instance.BubbleDestroyed();                                       // Plays the Bubble Destroyed sound.
                other.GetComponent<BabbleMove>().Split();                                   // Destroys this Bubble and spawns 2 more.
                other.GetComponent<PowerUpSystem>().RandomPopups(other.transform.position); // Spawns the reward for destroyed Bubble.

                if (name.Contains("Bubble S"))
                {
                    GameCtrl.instance.UpdateScore(Random.Range(100, 250));  // Updates game Score within given Range.
                }
                else if (name.Contains("Bubble M"))
                {
                    GameCtrl.instance.UpdateScore(Random.Range(350, 500));  // Updates game Score within given Range.
                }
                break;
            case "Breakable":
                BasicOne.IsFiredOne = false;                                                // Sets false, which disables weapon grow
                Destroy(other.gameObject);                                                  // Destroy the Breakable tile.
                break;
            default:
                //Debug.Log("This is strange gameObject TAG: " + other.tag);
                break;
        }
    }
}
