using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlantZone[] plantZones;
    private TreeGrowth[] trees;

    void Start()
    {
        plantZones = FindObjectsOfType<PlantZone>();
        trees = FindObjectsOfType<TreeGrowth>();
    }

    public void CheckVictory()
    {
        foreach (PlantZone zone in plantZones)
        {
            if (!zone.HasTree())
            {
                return; // Si alguna zona no tiene un árbol plantado, no hemos ganado aún.
            }
        }

        foreach (TreeGrowth tree in trees)
        {
            if (!tree.IsWatered())
            {
                return; // Si algún árbol no ha sido regado, no hemos ganado aún.
            }
        }

        // Si todas las zonas tienen árboles plantados y todos los árboles han sido regados y crecido, se ha ganado el juego.
        Victory();
    }

    private void Victory()
    {
        Debug.Log("¡Victoria! Todos los árboles han sido plantados y han crecido.");
        // Aquí puedes agregar lógica adicional para manejar la victoria, como mostrar un mensaje en pantalla o reiniciar el juego.
    }
}
