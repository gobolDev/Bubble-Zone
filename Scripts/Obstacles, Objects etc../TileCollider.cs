using UnityEngine;
/// <summary>
/// Handles the boost for Bubbles. This script is attached to Boost Tiles.
/// </summary>
public class TileCollider : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            Rigidbody2D otherRigid = collision.GetComponent<Rigidbody2D>(); // Takes the Rigid. Component of other collision body.

            if (transform.position.x >= 0)  // Determines current position of this gameobject.
            {
                if (otherRigid.velocity.y < 8 && otherRigid.velocity.y >= 0 && otherRigid.velocity.x < 0)   // Conditions for Bubble to receive a boost, when the Boost Tile has a positive X-axis.
                {
                    otherRigid.velocity = new Vector2(-3, 8);   // Sets boost for Bubble.
                }
            }
            else
            {
                if (otherRigid.velocity.y < 8 && otherRigid.velocity.y >= 0 && otherRigid.velocity.x > 0)   // Conditions for Bubble to receive a boost, when the Boost Tile has a negative X-axis.
                {
                    otherRigid.velocity = new Vector2(3, 8);    // Sets boost for Bubble. 
                }
            }
        }
    }
}
