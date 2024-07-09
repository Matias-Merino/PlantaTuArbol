using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantZone : MonoBehaviour
{
    private bool hasTree = false;

    public bool HasTree()
    {
        return hasTree;
    }

    public void PlantTree()
    {
        hasTree = true;
    }
}
