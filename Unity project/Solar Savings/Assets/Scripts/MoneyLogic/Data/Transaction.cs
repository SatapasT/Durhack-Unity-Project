using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction
{
    public int amount { get; set; }
    public System.DateTime time;

    public Transaction(int inputAmount, System.DateTime inputTime)
    {
        amount = inputAmount;
        time = inputTime;
    }

    public Transaction(int inputAmount){
        amount = inputAmount;
        time = System.DateTime.Now;
            }

    public void setValues(int inputAmount)
    {
        amount = inputAmount;
        time = System.DateTime.Now;
    }


}
