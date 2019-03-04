using UnityEngine;
/// <summary>
/// Handles bullets movement. This script is attached to Bullet Prefab.
/// </summary>
public class BulletSpeed : MonoBehaviour
{
    private string _name;   // Handles the name of this gameObject.

    void FixedUpdate ()
    {
        _name = gameObject.name;    // Assing a name of this gameObject in _name string variable.

        switch (name)   // Choose a case deppending of a taken name.
        {
            case "Space_Bullet_Left(Clone)":    // When the bullets name is.. do...
                transform.Translate(-1.5f * Time.deltaTime, 10 * Time.deltaTime, 0);   // Translate X: -2, Y: 10, Z: 0. On every frame update.
                break;                                                              // Stop.
            case "Space_Bullet_MidLeft(Clone)":    // When the bullets name is.. do...
                transform.Translate(-1 * Time.deltaTime, 10 * Time.deltaTime, 0);   // Translate X: -2, Y: 10, Z: 0. On every frame update.
                break;                                                              // Stop.
            case "Space_Bullet_Front(Clone)":   // When the bullets name is.. do...
                transform.Translate(0, 10 * Time.deltaTime, 0);                     // Translate X: 0, Y: 10, Z: 0. On every frame update.
                break;                                                              // Stop.
            case "Space_Bullet_MidRight(Clone)":   // When the bullets name is.. do...
                transform.Translate(1 * Time.deltaTime, 10 * Time.deltaTime, 0);    // Translate X: 2, Y: 10, Z: 0. On every frame update.
                break;                                                              // Stop.
            case "Space_Bullet_Right(Clone)":   // When the bullets name is.. do...
                transform.Translate(1.5f * Time.deltaTime, 10 * Time.deltaTime, 0);    // Translate X: 2, Y: 10, Z: 0. On every frame update.
                break;                                                              // Stop.
            default:                            // If their name doesn't match to any case.
                break;                          // Stop.
        }
	}
}
