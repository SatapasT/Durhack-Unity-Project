using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction
{
    public float amount { get; set; }
    public System.DateTime time;

    public Transaction(float inputAmount, System.DateTime inputTime)
    {
        amount = inputAmount;
        time = inputTime;
    }

    public Transaction(float inputAmount){
        amount = inputAmount;
        time = System.DateTime.Now;
            }

    public void setValues(float inputAmount)
    {
        amount = inputAmount;
        time = System.DateTime.Now;
    }


}
