using UnityEngine;
/// <summary>
/// Handles Collider collisions. This script is attached on StickyOne.
/// </summary>
public class StickyOneCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        string name = other.name;       // Sets the name of other gameObject to be in a string name variable.

        switch (other.tag)  // Checks case's by other gameObjects tag.
        {
            case "Wall":
                StickyOne.isStickOne = true;    // Sets to True, which disables further grow of weapon.
                Invoke("StickDelay", 5);        // Invokes StickyDelay method after 5 seconds.
                break;
            case "Enemies":
                SoundCtrl.instance.BubbleDestroyed();                                       // Plays the sound on Destoryed Bubble/
                other.GetComponent<BabbleMove>().Split();                                   // Calls Split() in other gameObject.
                other.GetComponent<PowerUpSystem>().RandomPopups(other.transform.position); // Calls RandomPopups() of other gameObject.
                CancelInvoke("StickDelay");                                                 // Cancels wait time of weapon.
                StickyOne.IsFiredOne = false;                                               // Sets false, which minimizes weapon.
                StickyOne.isStickOne = false;                                               // Sets false, enables grow of weapon.

                if(name.Contains("Bubble S"))
                {
                    GameCtrl.instance.UpdateScore(Random.Range(100, 250));  // Updates game Score within given Range.
                }
                else if(name.Contains("Bubble M"))
                {
                    GameCtrl.instance.UpdateScore(Random.Range(350, 500));  // Updates game Score within given Range.
                }
                break;
            case "Breakable":
                StickyOne.IsFiredOne = false;                                               // Sets false, which minimizes weapon.
                StickyOne.isStickOne = false;                                               // Sets false, enables grow of weapon.
                CancelInvoke("StickDelay");                                                 // Cancels wait time of weapon.
                SoundCtrl.instance.BubbleDestroyed();                                       // Plays the Bubble Destroyed sound.
                Destroy(other.gameObject);                                                  // Destroy the Breakable tile.
                break;
            default:
                //Debug.Log("There is no case for this gameObject TAG: " + other.tag);
                break;
        }
    }

    private void StickDelay()   // Called if the Sticky Arrow spend 5 seconds on the celling.
    {
        StickyOne.isStickOne = false;    // Sets false, which will enable Arrow to grow next time the Button is pressed.
        StickyOne.IsFiredOne = false;    // Sets false, which minimizes Sticky Arrow.
    }
}
