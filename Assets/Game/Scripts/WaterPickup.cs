using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviourPun
{
    private bool canPickup = false;
    private bool hasWater = false;

    public bool HasWater()
    {
        return hasWater;
    }

    public void UseWater()
    {
        hasWater = false;
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

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
            Debug.Log("Puedes recoger agua.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WaterSource"))
        {
            canPickup = false;
            Debug.Log("Has salido de la zona de recogida de agua.");
        }
    }
}
