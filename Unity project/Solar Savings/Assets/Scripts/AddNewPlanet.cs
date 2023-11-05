using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AddNewPlanet : MonoBehaviour
{
    [SerializeField] private GameObject OrbitLine;
    [HideInInspector] static int i = 1;
    [SerializeField] private GameObject planetPrefab;

    [SerializeField] private Sprite currentPlanetSprite;

    public void SetCurrentPlanetSprite(Sprite sprite)
    {
        currentPlanetSprite = sprite;
    }

    public void CreatePlanetInstance(string name)
    {
        Button planet = Instantiate(planetPrefab).GetComponent<Button>();
        GameObject parent = GameObject.Find("Solar System/Canvas/Planets");
        planet.transform.SetParent(parent.transform);
        planet.transform.localScale = new Vector3(1, 1, 1);

        PlanetScriptable planetScriptable = PlanetsListScriptables.instance.getNextPlanet();

        planetScriptable.isActive = true;
        planetScriptable.name = name;
        Debug.Log("Planet name: " + name);
        planetScriptable.sprite = currentPlanetSprite;
        planet.transform.localPosition = planetScriptable.position;
        planet.name = name;
        planet.GetComponentInChildren<TMP_Text>().text = name;
        planet.GetComponent<Image>().sprite = currentPlanetSprite;

        AddNewOrbitLine();
    }

    public void AddNewOrbitLine()
    {
        GameObject orbitLine = Instantiate(OrbitLine);

        Transform parent = this.transform.parent;

        RectTransform rt = orbitLine.GetComponent<RectTransform>();
        float width = rt.rect.width;
        float height = rt.rect.height;
        rt.sizeDelta = new Vector2(width + i*200, height + i*200);

        orbitLine.transform.SetParent(parent.transform.parent);
        orbitLine.transform.localScale = new Vector3(1, 1, 1);
        orbitLine.transform.localPosition = new Vector3(0, this.transform.parent.localPosition.y - i*55, 0);
        i++;
        Debug.Log("i: " + i);
        orbitLine.name = "Orbit" + i;

        orbitLine.gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;

    }
}
