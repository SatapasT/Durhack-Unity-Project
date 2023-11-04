using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;


public enum PlanetCategories
{
    None,
    Housing,
    Food,
    Transport,
    Savings,
    Insurance,
    Recreation,
    Other

}

public class PlanetManager : MonoBehaviour
{
    public GameObject planet;
    public GameObject planetHolder;
    public GameObject createPlanetMenu;

    public GameObject nameField;
    public GameObject descField;
    public GameObject budgetField;

    public PlanetCategories planetCategories;

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
        PlanetCategories planetIndex = (PlanetCategories)nameField.GetComponent<TMP_Dropdown>().value;
        string planetName = "";
        string planetDesc = descField.GetComponent<TMP_InputField>().text;
        string budgetInput = budgetField.GetComponent<TMP_InputField>().text;
        if (int.TryParse(budgetInput, out int result)){
            float num = (float)int.Parse(budgetInput);
            GameObject newPlanet = Instantiate(planet, planetHolder.transform);

            //PlanetData newPlanetData = 
            Debug.Log(planetIndex);
            switch (planetIndex) {

                case PlanetCategories.None:
                    break;
                case PlanetCategories.Housing:
                    break;
                case PlanetCategories.Food:
                    planetName = "Food";
                    break;
                case PlanetCategories.Transport: 
                    break;

            }

            newPlanet.GetComponent<PlanetData>().InputPlanetData(planetName,planetDesc,num,num);
            Debug.Log(newPlanet);
        
        }
        //int budgetVal =int.Parse(tempString);




    }

    
}
