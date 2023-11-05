using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class gestureController : MonoBehaviour
{


    //inside class
    private enum page
    {
        main,
        info1,
        info2,
        settings,
        achievements
    }

    page currPage = page.main;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    private void Update()
    {
        Swipe();
    }

    private void lerpAnchor(GameObject targetObj, Vector2 targetPos)
    {
        //targetObj.GetComponent<RectTransform>().pivot = Vector2.Lerp(targetObj.GetComponent<RectTransform>().pivot, new Vector2(0, 0), totalTime * Time.deltaTime);
        targetObj.GetComponent<RectTransform>().pivot = targetPos;
    }

    private void gestureControlUpSweep() //swipe bottom to up
    {
        if (currPage == page.main)
        {
            GameObject botPanel = GameObject.Find("bottomPanel");
            lerpAnchor(botPanel, new Vector2(0,0));
            currPage = page.info1;
        }
    }

    private void gestureControlLeftSweep() //swipe right to left
    {
        switch (currPage)
        {
            case (page.settings):
                GameObject setPanel = GameObject.Find("settingsPanel");
                lerpAnchor(setPanel, new Vector2(1,0));
                currPage = page.main;
                break;
            case (page.main):
                GameObject achPanel = GameObject.Find("achievementsPanel");
                lerpAnchor(achPanel, new Vector2(0,0));
                currPage = page.achievements;
                break;
            case (page.info1):
                GameObject in2Panel = GameObject.Find("bottomPanel2");
                lerpAnchor(in2Panel, new Vector2(0,0));
                currPage = page.info2;
                break;
        }
    }

    private void gestureControlRightSweep() //swipe left to right
    {
        switch (currPage)
        {
            case (page.achievements):
                GameObject achPanel = GameObject.Find("achievementsPanel");
                lerpAnchor(achPanel, new Vector2(-1, 0));
                currPage = page.main;
                break;
            case (page.main):
                GameObject setPanel = GameObject.Find("settingsPanel");
                lerpAnchor(setPanel, new Vector2(0, 0));
                currPage = page.settings;
                break;
            case (page.info2):
                GameObject botPanel2 = GameObject.Find("bottomPanel2");
                lerpAnchor(botPanel2, new Vector2(-1, 0));
                GameObject botPanel = GameObject.Find("bottomPanel");
                lerpAnchor(botPanel, new Vector2(0, 0));
                currPage = page.info1;
                break;
        }
    }

    private void gestureControlDownSweep() //swipe top to bottom
    {
        GameObject botPanel = GameObject.Find("bottomPanel");
        GameObject botPanel2 = GameObject.Find("bottomPanel2");
        switch (currPage)
        {
            case (page.info1):
                lerpAnchor(botPanel, new Vector2(0, (float)0.9));
                lerpAnchor(botPanel2, new Vector2(-1, 0));
                currPage = page.main;
                break;

            case (page.info2):
                lerpAnchor(botPanel, new Vector2(0, (float)0.9));
                lerpAnchor(botPanel2, new Vector2(-1, 0));
                currPage = page.main;
                break;
        }
    }
    
    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();


            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                gestureControlUpSweep();
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                gestureControlDownSweep();
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                gestureControlLeftSweep();
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                gestureControlRightSweep();
            }
            Debug.Log(currPage);
        }
    }
}
