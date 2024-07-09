using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTree : MonoBehaviour
{
    public GameObject treePrefab; // Prefab del árbol a plantar
    private bool canPlant = false;
    private PlantZone currentPlantZone;

    void Update()
    {
        if (canPlant && Input.GetKeyDown(KeyCode.E))
        {
            SeedPickup seedPickup = GetComponent<SeedPickup>();

            if (seedPickup != null && seedPickup.HasSeed() && currentPlantZone != null && !currentPlantZone.HasTree())
            {
                Instantiate(treePrefab, currentPlantZone.transform.position, Quaternion.identity);
                seedPickup.UseSeed();
                currentPlantZone.PlantTree();
                Debug.Log("Árbol plantado.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlantZone"))
        {
            currentPlantZone = other.GetComponent<PlantZone>();
            if (currentPlantZone != null && !currentPlantZone.HasTree())
            {
                canPlant = true;
                Debug.Log("Puedes plantar un árbol aquí.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlantZone"))
        {
            canPlant = false;
            currentPlantZone = null;
            Debug.Log("Has salido de la zona de plantación.");
        }
    }
}
