using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// Handles BasicOne Spike. This script is attached to BasicOne, in based gameOjbect.
/// </summary>
public class BasicOne : MonoBehaviour
{
    public static bool IsFiredOne, canFire; // Bools required for appropriate workflow.
    public Transform _playerTrans;          // Gives access to players Transform Component.
    private Transform spikeHead, spikeTail; // Transform Components of BasicOne Head and Tail.

	void Start ()
    {
        spikeTail = gameObject.transform.GetChild(0);                   // Gets the Transform Component.
        spikeHead = GetComponentInChildren<Transform>().GetChild(1);    // Gets the Transform Component.
        canFire = true;     // TESTING  // Enables player to fire basic Spike.
        IsFiredOne = false; // Disables spike being fired when scene is Restarted.
    }
	
	void Update ()
    {
        FiredOne();     // Enables Spike firing.
	}

    public void FiredOne()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && canFire && Time.timeScale == 1) // Conditions requierd to fire BasicOne Spike.
        {
            IsFiredOne = true;  // Sets true, enables Spike to grow.
        }

        if (IsFiredOne) // Checks Spike condition in each update.
        {
            ArrowGrow(true);    // Enables Spike to grow.
            spikeHead.gameObject.SetActive(true);   // Shows the gameObject.
        }
        else
        {
            ArrowGrow(false);   // Disables Spike to grow.
            spikeHead.gameObject.SetActive(false);  // Hides the gameObject.
        }
    }

    public void ArrowGrow(bool toGrow)  // Called in FiredOne.
    {
        if (toGrow) // If condition is true...
        {
            spikeHead.position += Vector3.up * Time.deltaTime / .168f;   // When fired Spike will keep its current position.
            spikeTail.localScale += Vector3.up * Time.deltaTime / 1.4f;  // Spike will increase its Scale on Y axis.
        }
        else
        {
            spikeTail.position = _playerTrans.position;                                                         // Spike's position will correspond to players position.
            spikeHead.position = new Vector2(_playerTrans.position.x + .005f, _playerTrans.position.y + .3f);   // Spike's position will correspond to players position.
            spikeTail.localScale = new Vector2(0.75f, 0);                                                       // Minimizes Spike, sets Spike's Y axis to 0.
        }
    }
}
