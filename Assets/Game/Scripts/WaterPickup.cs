using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviour
{
    private bool hasWater = false;
    private bool canPickup = false;

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            hasWater = true;
            Debug.Log("Agua recogida.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WaterSource"))
        {
            canPickup = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WaterSource"))
        {
            canPickup = false;
        }
    }

    public bool HasWater()
    {
        return hasWater;
    }

    public void UseWater()
    {
        hasWater = false;
    }
}
