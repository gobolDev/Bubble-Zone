using UnityEngine;
/// <summary>
/// Hides bullets. This script is attached to bullet Prefab.
/// </summary>
public class BulletDestroy : MonoBehaviour
{
    void OnEnable ()    // Called when Bullet spawns.
    {
        Invoke("Hide", 1f); // Invokes a Hide Method.
	}

    public void Hide()  // Called from Enabled, or, when Bullet hit the Bubble or the Cilling.
    {
        gameObject.SetActive(false);    // Hides the gameObject.
    }

    void OnDisable()    // Called when Bullet is Disabled.
    {   
        CancelInvoke(); // Cancels Invoke method before Script is being Disabled for this gameObject. 
    }
}
