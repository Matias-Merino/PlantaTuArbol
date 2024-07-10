using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    private bool watered = false;
    public float growthTime = 5f; // Tiempo que tarda en crecer el �rbol
    public GameObject grownTreePrefab; // Prefab del �rbol crecido
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public bool IsWatered()
    {
        return watered;
    }

    public void WaterTree()
    {
        watered = true;
        StartCoroutine(GrowTree());
    }

    private IEnumerator GrowTree()
    {
        yield return new WaitForSeconds(growthTime);
        Grow();
    }

    private void Grow()
    {
        // Instanciar el nuevo prefab del �rbol crecido en la misma posici�n y rotaci�n que el �rbol actual
        Instantiate(grownTreePrefab, transform.position, transform.rotation);
        // Destruir el prefab del �rbol original
        Destroy(gameObject);
        Debug.Log("El �rbol ha crecido.");
        gameManager.CheckVictory();
    }
}
