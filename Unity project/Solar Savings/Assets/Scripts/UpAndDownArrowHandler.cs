using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownArrowHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int i=0;
            //set trigger for all children
            foreach (Transform child in this.gameObject.transform)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Animator>().SetTrigger("ArrowDown");
                i++;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int i=0;
            //set trigger for all children
            foreach (Transform child in this.gameObject.transform)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Animator>().SetTrigger("ArrowUp");
                i++;
            }
        }
    }

    // public void ResetDownTrigger()
    // {
    //     int i=0;
    //     //reset trigger for all children
    //     foreach (Transform child in this.gameObject.transform)
    //     {
    //         this.gameObject.transform.GetChild(i).GetComponent<Animator>().ResetTrigger("ArrowDown");
    //         i++;
    //     }
    // }

    
}
