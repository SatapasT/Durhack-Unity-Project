using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/PlanetScriptable")]
public class PlanetScriptable : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public Vector2 position;
    public float monthlyBudget;
    public float usedBudget;

    public bool isActive;
    // public List<Transaction> transactions = new List<string>();

    public void OnValidate(){
        isActive = false;
    }
}
