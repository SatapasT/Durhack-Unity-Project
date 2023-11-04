using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public UserData userData;
    private string file = "userData.json";
    private string userTransactionFile = "userTransactions.txt";
    //private (int, System.DateTime) transaction;



    //need method for adding fixed amounts of money
    void Start() {
        if (!File.Exists(GetTransactionHistoryPath())) {
            File.CreateText("userTransactionFile,txt");
        }

 

        LoadData();

        Debug.Log(userData.transactionHistory.Count);
        AddFunds(-10);
        //AddFunds(-10);
        //AddFunds(-10);
        SaveData(userData);
    }




    void AddFunds (int amount)
    {
        userData.totalBalance += amount;
        //(int, System.DateTime) newTransaction = (amount, System.DateTime.Now);
        Transaction newTransaction = new Transaction(amount);
        userData.transactionHistory.Add(newTransaction);

        
    }

    

    void SaveData(UserData userData) {
        string json = JsonUtility.ToJson(userData);
        WriteToFile(file, json);
        SaveTransactionHistory();

    }

    void LoadData() {
        userData = new UserData();
        string json = ReadFromFile(file);
        if (json == null) { 
        }
        else { JsonUtility.FromJsonOverwrite(json, userData); }
        

        LoadTransactionHistory();
    }




    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not found");
            return null;
        }

        
    }

    private void SaveTransactionHistory() {
        string filePath = GetTransactionHistoryPath();


        StreamWriter writer = new StreamWriter(filePath, true);
        if (userData.transactionHistory.Count > 0) {
            foreach (Transaction item in userData.transactionHistory)
            {

                writer.Write(item.amount.ToString() + ",");
                writer.Write(item.time.ToString());
                writer.Write("\n");


            }
        }

        writer.Close();
    }

    private void LoadTransactionHistory() {
        string filePath = GetTransactionHistoryPath();
        if (File.Exists(GetTransactionHistoryPath()))
        {


            StreamReader reader = new StreamReader(filePath);


            string line;
            string[] splitString;
            int amount;
            System.DateTime time;

            while ((line = reader.ReadLine()) != null)
            {
                splitString = line.Split(',');
                amount = Convert.ToInt32(splitString[0]);
                time = DateTime.ParseExact(splitString[1], "dd/MM/yyyy HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture);

                Transaction newTransaction = new Transaction(amount, time);
                userData.transactionHistory.Add(newTransaction);


            }


            reader.Close();
            File.WriteAllText(filePath, "");
        }
        //SaveData(userData);
    }

    private string GetTransactionHistoryPath() {
        string filePath = Application.persistentDataPath + "/" + userTransactionFile;
        return filePath;
    }
}
