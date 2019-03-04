using UnityEngine;
/// <summary>
/// Handles collisions between Wall. This script is attached to Bullet Prefab.
/// </summary>
public class BulletCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Wall":
                gameObject.SetActive(false);    // Set this Bullet activity to false.
                break;
            case "Breakable":
                gameObject.SetActive(false);    // Set this Bullet activity to false.
                Destroy(other.gameObject);      // Destroy other gameObject.
                break;
        }
    }
}