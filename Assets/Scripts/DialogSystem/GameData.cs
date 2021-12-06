using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton Object to store all GameData
/// Is not destroyed when changing scenes
/// </summary>
public class GameData : MonoBehaviour
{
    public static GameData instanceRef; //null //variable that can point to a GameData object

    private int score;
    private int health;


    private Dictionary<string, string> choiceData = new Dictionary<string, string>();

    /// <summary>
    /// Properties - provide read/write access to variables
    /// </summary>

    public int Score
    {
        get { return score; } //Read access
                              // set { totalScore = value; }   //write access
    }

    public int Health
    {
        get { return health; } //read-only acccess
    }

    // Awake is called before Start() is called on any GameObject
    // Other objects have dependencies on this object so it must be created first
    void Awake()
    {
        if (instanceRef == null)  //this code hasn't been executed before
        {
            instanceRef = this; //point to object instance currently executing this code
            DontDestroyOnLoad(this.gameObject); //don't destroy the gameObject this is attached to
        }
        else  //this object is not the first, it's an imposter that must be destroyed
        {
            DestroyImmediate(this.gameObject);
            Debug.Log("Destroy GameData Imposter");
        }
       


    } //end Awake

    //will be executed in PlayerController when colliding with a collectible
    public void Add(int value)
    {
        score += value;
        Debug.Log("Score updated: " + score); //display score in console
    }// end Add

    public void TakeDamage(int value)
    {
        health -= value;
        Debug.Log("health updated: " + health); //display health in console
        if (health <= 0)
        {
            Debug.Log("Health less than 0"); //display health in console
        }
    }//end TakeDamage

    /*uses score points to purchase something
    public void Buy(int value)
    {
        score -= value;
        Debug.Log("Buy: score reduced " + score);
    }

    //increases player health
    public void BoostHealth(int value)
    {
        health += value;
        health = Mathf.Min(health, 100);
        Debug.Log("boosting health, new health " + health);
    }
    */



    //save any <string, string > key-value pair in choiceData dictionary
    public void SaveChoice(string choiceKey, string choiceValue)
    {
        if (choiceData.ContainsKey(choiceKey))
        {
            choiceData[choiceKey] = choiceValue; //change stored value
            Debug.Log("Choice Changed" + choiceKey + " : " + choiceValue);
        }
        else
        {
            choiceData.Add(choiceKey, choiceValue); //adds key,value pair
            Debug.Log("Choice Data Created" + choiceKey + " : " + choiceValue);
        }

    }

    //given key, read any < string, string > key-value pair 
    public string GetChoice(string choiceKey)
    {
        string choiceValue = "None";
        choiceData.TryGetValue(choiceKey, out choiceValue);
        Debug.Log("Choice Data Accessed" + choiceKey + " : " + choiceValue);

        return choiceValue;
    }

    //removes item from dictionary if key exists
    public void RemoveChoice(string choiceKey)
    {
        if (choiceData.ContainsKey(choiceKey))
        {
            choiceData.Remove(choiceKey);

        }
    }


    //called when restarting the miniGame
    public void ResetGameData()
    {
        score = 0;
        health = 100;
    }


}//end class GameData