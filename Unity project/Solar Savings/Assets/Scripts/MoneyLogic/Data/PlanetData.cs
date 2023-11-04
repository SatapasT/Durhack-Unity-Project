using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class PlanetData
{
    public string name;
    public string description;


    public float setBudget;
    public float outgoingAmount;
    public List<Transaction> transactions = new List<Transaction>();

    public PlanetData(string inputName, string inputDesc, float inputSetBudget, float inputOutgoingAmount)
    {
        name = inputName;
        description = inputDesc;
        setBudget = inputSetBudget;
        outgoingAmount = inputOutgoingAmount;

    }
}
