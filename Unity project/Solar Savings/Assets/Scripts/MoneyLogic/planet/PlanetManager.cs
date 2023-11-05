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

    public List<GameObject> PlanetList = new List<GameObject>();
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
        float hardcoded_food = 273.34f;
        if (float.TryParse(budgetInput, out float result)){
            float num = (float)float.Parse(budgetInput);
            GameObject newPlanet = Instantiate(planet, planetHolder.transform);

            //PlanetData newPlanetData = 
            switch (planetIndex) {
                case PlanetCategories.None:
                    break;
                case PlanetCategories.Housing:
                    break;
                case PlanetCategories.Food:
                    planet.GetComponent<PlanetData>().planetCategories = PlanetCategories.Food;
                    planetName = "Food";
                    float changeInSpendingHabit = num - hardcoded_food;
                    float yearlyChangeInHabit = changeInSpendingHabit * 12;
                    bool lessSpendingThanLastYear = (num < hardcoded_food);
                    float percentageChange = ((num - hardcoded_food) / hardcoded_food) * 100;
                    Debug.Log($"Increase in monthly spending on food : £{changeInSpendingHabit}");
                    Debug.Log($"Increase Yearly spending in food based on this month: £{yearlyChangeInHabit}");
                    Debug.Log($"You spend less than last year: {lessSpendingThanLastYear}");
                    Debug.Log($"Percentage Change in Food Budget: {percentageChange}%");
                    break;
                case PlanetCategories.Transport: 
                    break;

            }

            newPlanet.GetComponent<PlanetData>().InputPlanetData(planetName,planetDesc,num,num);
            Debug.Log(newPlanet);

            CheckForPreviousPlanets(planet.GetComponent<PlanetData>());
        
        }
        //int budgetVal =int.Parse(tempString);



        void CheckForPreviousPlanets(PlanetData planetData) { 
            
        
        }
    }

    
}
