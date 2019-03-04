using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// Handles StickyOne Spike. This script is attached to StickyOne Spike, in based gameobject. 
/// </summary>
public class StickyOne : MonoBehaviour
{
    public static bool canFire, IsFiredOne, isStickOne; // Bools required for appropriate workflow.
    public Transform _playerTrans;                      // Reference to players position.
    private Transform stickyHead, stickyTail;           // Transform Components of StickyOne Head and Tail.

    private void Start()
    {
        stickyTail = gameObject.transform.GetChild(0);                  // Gets the Transform Component.
        stickyHead = GetComponentInChildren<Transform>().GetChild(1);   // Gets the Transform Component.
        canFire = false;    // This makes sure that it value is always set to false on each Scene Reload on Enter.
        IsFiredOne = false; // This makes sure that it value is always set to false on each Scene Reload on Enter.
        isStickOne = false; // This makes sure that it value is always set to false on each Scene Reload on Enter.
    }

    void Update()
    {
        FiredOne(); // Calls FiredOne method.
    }

    public void FiredOne()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && canFire && Time.timeScale == 1) // Conditions for firing Sticky Arrow.
        {
            IsFiredOne = true;  // Sets True.
        }

        if (IsFiredOne)         // Checking the current condition.
        {
            ArrowGrow(true);    // Calls ArrowGrow method with paramether "true".
            stickyHead.gameObject.SetActive(true);  // Shows the StickyHead.
        }
        else
        {
            ArrowGrow(false);   // Calls ArrowGrow method with paramether "false".
            stickyHead.gameObject.SetActive(false); // Hides the StickyHead.
        }
    }

    private void ArrowGrow(bool toGrow) //  Called from Update to enable Arrow to grow or minimize.
    {
        if (toGrow) // Condition checker for further action.
        {
            if (!isStickOne)   // Checks if the Arrow reached the ceiling. Inverts the value. True > False | False > True.
            {
                stickyTail.localScale += Vector3.up * Time.deltaTime / 1.4f;  // Moves the scale Up.
                stickyHead.position += Vector3.up * Time.deltaTime / 0.168f;     // Increases Y position of Spike's head.
            }
            else
            {
                stickyTail.localScale = stickyTail.localScale;  // Keeps the current Scale value.
                stickyHead.position = stickyHead.position;      // Keeps the current Position value.
            }
            transform.position = transform.localPosition;   // Sets the position to be the position when player fired it.
        }
        else
        {
            transform.position = new Vector2(_playerTrans.position.x, _playerTrans.position.y + .02f);  // Sets the position equal to players position.
            stickyTail.localScale = new Vector2(0.75f, 0);                                              // Sets the Scale to 0 on Y axis.
            stickyHead.position = new Vector2(_playerTrans.position.x, _playerTrans.position.y + .2f);  // Sets the position equal to players position.
        }
    }
}
