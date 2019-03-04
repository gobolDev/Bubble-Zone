using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Handles collision between Player and collectable objects. This script is attached to Collectable Prefabs.
/// </summary>
public class Reward : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))       // If the other collided object is tagged as Player.
        {
            switch(name)
            {
                case "500points(Clone)":
                    GameCtrl.instance.UpdateScore(500);     // Updates Score with 500 points.
                    break;
                case "1000points(Clone)":
                    GameCtrl.instance.UpdateScore(1000);    // Updates Score with 1000 points.
                    break;
                case "2000points(Clone)":
                    GameCtrl.instance.UpdateScore(2000);    // Updates Score with 2000 points.
                    break;
                case "5000points(Clone)":
                    GameCtrl.instance.UpdateScore(5000);    // Updates Score with 5000 points.
                    break;
                case "Create_StickyOne(Clone)":
                    StickyOne.canFire = true;               // Enable StickyOne Spike use.
                    StickyTwo.canFire = false;              // Disables StickyTwo Spike use.
                    BasicOne.canFire = false;               // Disable BasicOne Spike use.
                    Gun.hasGun = false;                     // Disable Gun use.
                    break;
                case "Create_StickyTwo(Clone)":
                    StickyOne.canFire = true;               // Enable StickyOne Spike use.
                    StickyTwo.canFire = true;               // Enable StickyTwo Spike use.
                    BasicOne.canFire = false;               // Disable BasicOne Spike use.
                    Gun.hasGun = false;                     // Disable Gun use.
                    break;
                case "Create_BasicOne(Clone)":  
                    BasicOne.canFire = true;                // Enable BasicOne Spike use.
                    StickyOne.canFire = false;              // Disable StickyOne Spike use.
                    Gun.hasGun = false;                     // Disable Gun use.
                    break;
                case "Create_BasicTwo(Clone)":
                    BasicOne.canFire = true;                // Enable BasicOne Spike use.
                    BasicTwo.canFire = true;                // Enable BasicTwo Spike use.
                    StickyOne.canFire = false;              // Disable StickyOne Spike use.
                    Gun.hasGun = false;                     // Disable Gun use.
                    break;
                case "Create_Gun(Clone)":
                    Gun.hasGun = true;                      // Enables Gun use.
                    BasicOne.canFire = false;               // Disables BasicOne use.
                    StickyOne.canFire = false;              // Disables StickyOne use.
                    break;
                default:
                    Debug.Log("There is no case for collided object: " + name);
                    break;
            }
            Destroy(gameObject);    // Destroy this.
        }
        Destroy(gameObject, 8);    // Destroy this after 8 second delay.
    }
}
