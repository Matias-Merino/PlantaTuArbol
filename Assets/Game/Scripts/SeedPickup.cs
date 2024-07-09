using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickup : MonoBehaviour
{
    private bool hasSeed = false;
    private bool canPickup = false;

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            hasSeed = true;
            Debug.Log("Semilla recogida.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SeedBox"))
        {
            canPickup = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SeedBox"))
        {
            canPickup = false;
        }
    }

    public bool HasSeed()
    {
        return hasSeed;
    }

    public void UseSeed()
    {
        hasSeed = false;
    }
}
