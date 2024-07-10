using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviourPun
{
    public bool canPickup = false;
    public bool hasWater = false;

    void Update()
    {
        if (!photonView.IsMine)
            return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E presionada");
        }
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
    public bool HasWater()
    {
        return hasWater;
    }

    public void UseWater()
    {
        hasWater = false;
    }
}
