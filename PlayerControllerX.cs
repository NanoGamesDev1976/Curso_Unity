using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float fireDelay = 1f;
    private float counter = 0f;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime; 
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (counter>=fireDelay)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                counter = 0;
            }
        }
    }
}
