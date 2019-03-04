using UnityEngine;
/// <summary>
/// Handles Collider collision. This script is attached on StickyTwo.
/// </summary>
public class StickyTwoCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        string name = other.name;       // Sets the name of other gameObject to be in a string name variable.

        switch (other.tag)  // Checks case's by other gameObjects tag.
        {
            case "Wall":        // # 1
                StickyTwo.isStickTwo = true;    // Sets to true, which disables further grow of weapon.
                Invoke("StickDelay", 5);        // Invokes StickDelay method with 5 second delay.
                break;
            case "Enemies":     // # 2
                SoundCtrl.instance.BubbleDestroyed();                                       // Plays the sound when Bubble is Destroyed.
                other.GetComponent<BabbleMove>().Split();                                   // Calls Split() of other gameObject.
                other.GetComponent<PowerUpSystem>().RandomPopups(other.transform.position); // Calls RandomPopups() of other gameObject.
                CancelInvoke("StickDelay");                                                 // Cancels StickDelay().
                StickyTwo.isStickTwo = false;                                               // Sets false, which minimizes weapon.
                StickyTwo.IsFiredTwo = false;                                               // Sets false, which enables grow of weapon.

                if (name.Contains("Bubble S"))
                {
                    GameCtrl.instance.UpdateScore(Random.Range(100, 250));  // Updates game Score within given Range.
                }
                else if (name.Contains("Bubble M"))
                {
                    GameCtrl.instance.UpdateScore(Random.Range(350, 500));  // Updates game Score within given Range.
                }
                break;
            case "Breakable":   // # 3
                StickyTwo.isStickTwo = false;                                               // Sets false, which disables weapon grow
                StickyTwo.IsFiredTwo = false;                                               // Sets false, which enables grow of weapon.
                CancelInvoke("StickDelay");                                                 // Cancels StickDelay().
                SoundCtrl.instance.BubbleDestroyed();                                       // Plays the Bubble Destroyed sound.
                Destroy(other.gameObject);                                                  // Destroy the Breakable tile.
                break;
            default:            // # 0
                //Debug.Log("There is no case for gameObject TAG: " + other.tag);
                break;
        }
    }

    private void StickDelay()   // Called if the weapon spend 5 second on celling.
    {
        StickyTwo.isStickTwo = false;   // Sets false, which will enable weapon to grow next time the Button is pressed.
        StickyTwo.IsFiredTwo = false;   // Sets false, which minimizes weapon.
    }
}