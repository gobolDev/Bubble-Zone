using UnityEngine;
/// <summary>
/// Handles collision for BasicTwo. This script is attached to BasicTwo.
/// </summary>
public class BasicTwoCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        string name = other.name;   // Holds the name of collided gameObject.

        switch (other.tag)  // Checks case's by other gameObjects tag.
        {
            case "Wall":
                BasicTwo.IsFiredTwo = false;                                                // Disable Spike Grow.
                break;
            case "Enemies":
                BasicTwo.IsFiredTwo = false;                                                // Sets false, which disables weapon grow.
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
                BasicTwo.IsFiredTwo = false;                                                // Sets false, which disables weapon grow
                SoundCtrl.instance.BubbleDestroyed();                                       // Plays the Bubble Destroyed sound.
                Destroy(other.gameObject);                                                  // Destroy the Breakable tile.
                break;
        }
    }
}
