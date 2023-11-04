using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public GameObject planet;
    public GameObject createPlanetMenu;

    public GameObject nameField;
    public GameObject descField;
    public GameObject budgetField;

    private bool creationInProgress = false;

    private void Start()
    {
        createPlanetMenu.SetActive(false);
    }
    public void CreateNewPlanet() {
        if (!creationInProgress) {
            createPlanetMenu.SetActive(true);
            creationInProgress = true;
            //Instantiate(planet);



        }
    }

    public void CheckBudgetInput() { 
    
    }


    public void ConfirmPlanetCreation()
    {

        string planetName = descField.GetComponent<TMP_InputField>().text;
        string budgetInput = budgetField.GetComponent<TMP_InputField>().text;
        if (int.TryParse(budgetInput, out int result)){
            float num = (float)int.Parse(budgetInput);
            PlanetData newPlanet = new PlanetData(planetName,planetName,num,num);
            Debug.Log(newPlanet);
        
        }
        //int budgetVal =int.Parse(tempString);




    }

    
}
