using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float spawnInterval = 1.0f;
    public GameObject dogPrefab;
    private float timeDelay = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
         timeDelay += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timeDelay > spawnInterval)
            {
                timeDelay = 0;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
    }
}
