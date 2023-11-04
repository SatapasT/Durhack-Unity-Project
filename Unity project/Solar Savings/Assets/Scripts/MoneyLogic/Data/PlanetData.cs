using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public string planetName;
    public string description;


    public float setBudget;
    public float outgoingAmount;
    public List<Transaction> transactions = new List<Transaction>();

    public void InputPlanetData(string inputName, string inputDesc, float inputSetBudget, float inputOutgoingAmount)
    {
        planetName = inputName;
        description = inputDesc;
        setBudget = inputSetBudget;
        outgoingAmount = inputOutgoingAmount;

    }

    public void OnClick() {

        Debug.Log(planetName);
            }
}
