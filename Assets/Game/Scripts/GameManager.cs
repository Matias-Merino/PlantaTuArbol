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
                return; // Si alguna zona no tiene un �rbol plantado, no hemos ganado a�n.
            }
        }

        foreach (TreeGrowth tree in trees)
        {
            if (!tree.IsWatered())
            {
                return; // Si alg�n �rbol no ha sido regado, no hemos ganado a�n.
            }
        }

        // Si todas las zonas tienen �rboles plantados y todos los �rboles han sido regados y crecido, se ha ganado el juego.
        Victory();
    }

    private void Victory()
    {
        Debug.Log("�Victoria! Todos los �rboles han sido plantados y han crecido.");
        // Aqu� puedes agregar l�gica adicional para manejar la victoria, como mostrar un mensaje en pantalla o reiniciar el juego.
    }
}
