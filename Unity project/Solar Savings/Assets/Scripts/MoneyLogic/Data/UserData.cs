using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public float totalBalance;

    //public List<(int, System.DateTime)> transactionHistory = new List<(int, System.DateTime)>();
    public List<Transaction> transactionHistory = new List<Transaction>();
}
