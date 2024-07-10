using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTree : MonoBehaviourPun
{
    private bool canWater = false;
    private TreeGrowth currentTree;

    void Update()
    {
        if (!photonView.IsMine)
            return;

        if (canWater && Input.GetKeyDown(KeyCode.E))
        {
            WaterPickup waterPickup = GetComponent<WaterPickup>();

            if (waterPickup != null && waterPickup.HasWater() && currentTree != null && !currentTree.IsWatered())
            {
                waterPickup.UseWater();
                currentTree.WaterTree();
                Debug.Log("�rbol regado.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            currentTree = other.GetComponent<TreeGrowth>();
            if (currentTree != null && !currentTree.IsWatered())
            {
                canWater = true;
                Debug.Log("Puedes regar este �rbol.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            canWater = false;
            currentTree = null;
            Debug.Log("Has salido de la zona del �rbol.");
        }
    }
}
