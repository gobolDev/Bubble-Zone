﻿using UnityEngine;
/// <summary>
/// Handles PowerUp spawn. This script is attached to Bubble Prefab. 
/// </summary>
public class PowerUpSystem : MonoBehaviour
{
    public static PowerUpSystem instance;
    public GameObject points500, points1000, points2000, points5000, basicOne, basicTwo, stickyOne, stickyTwo, gun;

    public void Start()
    {
        if(instance == null)
        {
            instance = this;    // Creates an Instance of this script.
        }
    }

    public void RandomPopups(Vector3 myPos)     // Called when Bubble is Destroyed, requiers Vector3 paramether on call.
    {
        int number = Random.Range(min: 0, max: 20); // Creates Random number between 0 and 20! ( number 20 in not included) 
        Debug.Log(number);                          // Prints number to console.
        GameObject[] Array = new GameObject[9];     // Creates new GameObject Array.

        Array[0] = points500;   // Contains 500 points reward.
        Array[1] = points1000;  // Contains 1000 points reward.
        Array[2] = points2000;  // Contains 2000 points reward.
        Array[3] = points5000;  // Contains 5000 points reward.
        Array[4] = basicOne;    // Contains basicOne Spike power-up.
        Array[5] = basicTwo;    // Contains basicTwo Spike power-up.
        Array[6] = gun;         // Contains gun power-up.
        Array[7] = stickyOne;   // Contains stickyOne Spike power-up.
        Array[8] = stickyTwo;   // Contains stickyTwo Spike power-up.

        switch (number) // Contains Random number value.
        {
            case 1:
                Instantiate(points500, transform.position, Quaternion.identity);    // Instantiates 500 points Prefab.
                break;
            case 5:
                Instantiate(points1000, transform.position, Quaternion.identity);   // Instantiates 1000 points Prefab.
                break;
            case 8:
                Instantiate(points2000, transform.position, Quaternion.identity);   // Instantiates 2000 points Prefab.
                break;
            case 9:
                Instantiate(points5000, transform.position, Quaternion.identity);   // Instantiates 5000 points Prefab.
                break;
            case 10:
                if(!BasicOne.canFire && StickyOne.canFire)  // !! If BasicOne is FALSE & StickyOne is TRUE. Spawn BasicOne. 
                {
                    Instantiate(basicOne, transform.position, Quaternion.identity);     // Instantiates BasicOne Create Prefab.
                }
                break;
            case 11:
                Instantiate(basicTwo, transform.position, Quaternion.identity); // Instantiates basicTwo Create Prefab.
                break;
            case 12:
                Instantiate(gun, transform.position, Quaternion.identity);      // Instantiates gun Create Prefab.
                break;
            case 15:
                Instantiate(stickyOne, transform.position, Quaternion.identity);// Instantiates stickyOne Create Prefab.
                break;
            case 16:
                if (StickyOne.canFire)  // If StickyOne is TRUE. Spawn StickyTwo reward box.
                {
                    Instantiate(stickyTwo, transform.position, Quaternion.identity);    // Instantiates StickyTwo Create Prefab.
                }
                break;
        }
    }
}
