using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsListScriptables : MonoBehaviour
{

    public static PlanetsListScriptables instance;
    public List<PlanetScriptable> planets = new List<PlanetScriptable>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public PlanetScriptable getNextPlanet()
    {
        foreach (PlanetScriptable planet in planets)
        {
            if (!planet.isActive)
            {
                return planet;
            }
        }
        return null;
    }
}
