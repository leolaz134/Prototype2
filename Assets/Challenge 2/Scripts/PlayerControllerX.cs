using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    //Cooldown times for spawning dog
    private float cooldownTime = 1.0f;
    //We first set last action to negative so the player can spawn the dog right away
    private float lastActionTime = -1.0f;

    // Update is called once per frame
    void Update()
    {
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastActionTime + cooldownTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastActionTime = Time.time;
        }
        
    }
}
