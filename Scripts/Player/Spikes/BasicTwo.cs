using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
/// <summary>
/// Handles BasicTwo Spike. This script is attached to BasicTwo, in based gameObject.
/// </summary>
public class BasicTwo : MonoBehaviour
{
    public static bool IsFiredTwo, canFire; // Bools required for appropriate workflow.
    public Transform _playerTrans;          // Gives access to players Transform Component.
    private Transform spikeHead, spikeTail; // Transform Components of BasicTwo Head and Tail.

    private void Start ()
    {
        spikeTail = gameObject.transform.GetChild(0);                   // Gets the Transform Component.
        spikeHead = GetComponentInChildren<Transform>().GetChild(1);    // Gets the Transform Component.
        canFire = true;        // This makes sure that it's value is always set to false on each Scene Reload on Enter.
        IsFiredTwo = false;     // This makes sure that it's value is always set to false on each Scene Reload on Enter.
    }
	
	private void FixedUpdate ()
    {
        FiredTwo();     // Enables Spike firing.
    }

    private void FiredTwo()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && BasicOne.IsFiredOne && canFire)    // Conditions requierd to fire BasicTwo Spike.
        {
            IsFiredTwo = true;  // Sets true, enables Spike to grow.
        }

        if (IsFiredTwo && canFire)  // Checks Spike condition in each update.
        {
            ArrowGrow(true);    // Enables Spike to grow.
            spikeHead.gameObject.SetActive(true);   // Shows the gameObject.
        }
        else
        {
            ArrowGrow(false);   // Disables Spike to grow.
            spikeHead.gameObject.SetActive(false);   // Hides the gameObject.
        }
    }

    private void ArrowGrow(bool toGrow)  // Called in FiredOne.
    {
        if (toGrow) // If toGrow is true... else ...
        {
            spikeHead.position += Vector3.up * Time.deltaTime / .168f;   // When fired Spike will keep its current position.
            spikeTail.localScale += Vector3.up * Time.deltaTime / 1.4f;  // Spike will increase its Scale on Y axis.        
        }
        else
        {
            spikeTail.position = _playerTrans.position;                                                         // Spike's position will correspond to players position.
            spikeHead.position = new Vector2(_playerTrans.position.x + .005f, _playerTrans.position.y + .3f);   // Spike's position will correspond to players position.
            spikeTail.localScale = new Vector2(0.75f, 0);                                                       // Sets the scale of Spikes Tail to normal values.
        }   
    }
}
