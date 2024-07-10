using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    private bool watered = false;
    public float growthTime = 5f; // Tiempo que tarda en crecer el árbol
    public GameObject grownTreePrefab; // Prefab del árbol crecido
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
        // Instanciar el nuevo prefab del árbol crecido en la misma posición y rotación que el árbol actual
        Instantiate(grownTreePrefab, transform.position, transform.rotation);
        // Destruir el prefab del árbol original
        Destroy(gameObject);
        Debug.Log("El árbol ha crecido.");
        gameManager.CheckVictory();
    }
}
