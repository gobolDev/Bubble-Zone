using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// Handles object pooling. This script is attached to the Player.
/// </summary>
public class Gun : MonoBehaviour
{
    public static bool hasGun;      // Enables player to use gun.
    List<GameObject> bullets;       // List that includes copies of GameObject bullet.
    public GameObject bullet;       // Prefab on Bullet requiered for List.
    private int pooledAmount = 25;  // Amount of created bullets in List.

    void Start ()
    {
        hasGun = false;             // TESTING  // THIS BOOL NEEDS TO BE !"FALSE"! WHEN DEPLOYING! 

        bullets = new List<GameObject>();       // Creates a new List of GameObjects!
        for(int i = 0; i< pooledAmount; i++)    // Loads bullets!
        {
            GameObject obj = Instantiate(bullet);   // Creates a Clip.
            obj.SetActive(false);                   // Hides every Instantiated bullet.
            bullets.Add(obj);                       // Adds every Instantiated bullet in Clip.
        }
    }

    void Update()
    {
        Weapon();   // Calls Weapon method.
    }

    void Weapon()   // Called from the Update.
    {   
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && Time.timeScale == 1)   // Conditions required to fire a Bullet.
        {
            Fire(); // Calls a Fire method.
        }
    }

    void Fire() // Called from Weapon method. This script fires bullets! 
    {
        if (hasGun) // Condition that checks, in Reward Script, if the player collected "gun" PowerUp.
        {
            SoundCtrl.instance.WeaponSound();       // Plays the sound when Bullet has been fired!

            for (int i = 0; i < bullets.Count; i++) // Checks if "i" is lower than actual size of List, if so..
            {
                if (!bullets[i].activeInHierarchy)  // Checks available bullets that are not active in Hierarchy.
                {
                    bullets[i].transform.position = transform.TransformPoint(-0.2f, 1.2f, 0f);  // Sets new Transform position of selected bullet.
                    bullets[i].name = "Space_Bullet_Left(Clone)";                           // Sets new name of the Prefab.
                    bullets[i].SetActive(true);                                             // Shows the selected bullet.
                    break;                                                                  // Stops the loop.
                }
            }

            for (int i = 0; i < bullets.Count; i++) // Checks if "i" is lower than actual size of List, if so..
            {
                if (!bullets[i].activeInHierarchy)  // Checks available bullets that are not active in Hierarchy.
                {
                    bullets[i].transform.position = transform.TransformPoint(0, 1.3f, 0f);  // Sets new Transform position of selected bullet.
                    bullets[i].name = "Space_Bullet_MidLeft(Clone)";                           // Sets new name of the Prefab.
                    bullets[i].SetActive(true);                                             // Shows the selected bullet.
                    break;                                                                  // Stops the loop.
                }
            }

            for (int i = 0; i < bullets.Count; i++) // Checks if "i" is lower than actual size of List, if so..
            {
                if (!bullets[i].activeInHierarchy)  // Checks available bullets that are not active in Hierarchy.
                {
                    bullets[i].transform.position = transform.TransformPoint(0, 1.5f, 0);   // Sets new Transform position of selected bullet.
                    bullets[i].name = "Space_Bullet_Front(Clone)";                          // Sets new name of the Prefab.
                    bullets[i].SetActive(true);                                             // Shows the selected bullet.
                    break;                                                                  // Stops the loop.
                }
            }

            for (int i = 0; i < bullets.Count; i++) // Checks if "i" is lower than actual size of List, if so..
            {
                if (!bullets[i].activeInHierarchy)  // Checks available bullets that are not active in Hierarchy.
                {
                    bullets[i].transform.position = transform.TransformPoint(0, 1.3f, 0f);  // Sets new Transform position of selected bullet.
                    bullets[i].name = "Space_Bullet_MidRight(Clone)";                       // Sets new name of the Prefab.
                    bullets[i].SetActive(true);                                             // Shows the selected bullet.
                    break;                                                                  // Stops the loop.
                }
            }

            for (int i = 0; i < bullets.Count; i++) // Checks if "i" is lower than actual size of List, if so..
            {
                if (!bullets[i].activeInHierarchy)  // Checks available bullets that are not active in Hierarchy.
                {
                    bullets[i].transform.position = transform.TransformPoint(0.2f, 1.2f, 0f);   // Sets new Transform position of selected bullet.
                    bullets[i].name = "Space_Bullet_Right(Clone)";                          // Sets new name of the Prefab.
                    bullets[i].SetActive(true);                                             // Shows the selected bullet.
                    break;                                                                  // Stops the loop.
                }
            }
        }
    }
}
