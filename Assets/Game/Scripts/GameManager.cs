using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    private PlantZone[] plantZones;
    private TreeGrowth[] trees;
    private UIManager uiManager;

    public GameObject uiPrefab; // Arrastra aquí el prefab de la UI desde el Inspector

    void Start()
    {
        plantZones = FindObjectsOfType<PlantZone>();
        trees = FindObjectsOfType<TreeGrowth>();

        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Instancia el prefab del UI para ambos jugadores
            GameObject uiInstance = PhotonNetwork.Instantiate(uiPrefab.name, Vector3.zero, Quaternion.identity);
            uiManager = uiInstance.GetComponent<UIManager>();
        }
    }

    public void OnTreePlanted()
    {
        if (uiManager != null)
        {
            uiManager.AddScore(1);
        }
        CheckVictory();
    }

    public void CheckVictory()
    {
        foreach (PlantZone zone in plantZones)
        {
            if (!zone.HasTree())
            {
                return;
            }
        }

        foreach (TreeGrowth tree in trees)
        {
            if (!tree.IsWatered())
            {
                return;
            }
        }

        Victory();
    }

    private void Victory()
    {
        Debug.Log("¡Victoria! Todos los árboles han sido plantados y han crecido.");
        // logic
    }
}
