using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    [Header("Database Stuff")]
    public TextAsset databaseFile;
    public List<Character> database = new List<Character>();

    // Start is called before the first frame update
    private void Awake()
    {
        BuildDatabase();
    }

    //-----------------------------------------------------------
    // is called during initialization to have a database ready
    //-----------------------------------------------------------
    private void BuildDatabase()
    {
        //-------------------------------------------------------
        // start reading text from the file to build a database
        //-------------------------------------------------------
        string dataText = databaseFile.text;
        string[] chars = dataText.Split('\n');
        
        //------------------------------------------------------------------------------
        // chance is incremented everytime a character is added to database
        // the list is traversed from bottom up to determine which character is rolled
        // masterChance is kept for future calculations of actual roll chance
        //------------------------------------------------------------------------------
        float chance = 0f;

        foreach(var c in chars)
        {
            //-------------------------------------
            // split data using '/' as a splitter
            //
            // data lines use the following format:
            // ID / Name / Roll Chance
            //-------------------------------------
            string data = c;

            int index = data.IndexOf('/');

            //id
            int id = int.Parse(data.Substring(0, index)) - 1;
            data = data.Substring(index + 1);

            //name
            index = data.IndexOf('/');
            string name = data.Substring(0, index);
            
            //masterChance
            float masterChance = float.Parse(data.Substring(index + 1));

            //chance
            chance += masterChance;

            database.Add(new Character(id, name, masterChance, chance));
        }
    }

    //------------------------
    // rolls for a character
    //------------------------
    public Character Roll()
    {
        //----------------------------------
        // subtract points and do the roll
        //----------------------------------
        PersistentData.instance.SubtractPoints(999);

        Character toReturn;
        float roll = Random.value;
        for (int i = 0; i < database.Count; ++i)
        {
            //---------------------------------------------------------------
            // successful roll, exit the loop and return rolled character
            // otherwise, continue iterating through the database
            //---------------------------------------------------------------
            if (roll < database[i].chance || i == database.Count - 1)
            {
                database[i].owned = true;
                toReturn = database[i];
                UpdateChances();
                return toReturn;
            }
        }
        //------------------------------------
        // the code should never return null
        //------------------------------------
        return null;
    }


    //--------------------------------------------------------------------------------
    // is called whenever a character is unlocked in order to update to roll chances
    //--------------------------------------------------------------------------------
    public void UpdateChances()
    {
        int ownedCount = 0;
        float totalRolled = 0f;

        for (int i = 0; i < database.Count; ++i)
        {
            //---------------------------------------------------------------
            // check through the database and see if the character is owned
            // if the character is owned, set its chance of rolling to 0
            //---------------------------------------------------------------
            if (database[i].owned)
            {
                database[i].DisableRoll();
                totalRolled += database[i].GetMasterChance();
                ++ownedCount;
            }
        }

        //----------------------------------------------------------------------------
        // sort the database and calculate new roll chances for remaining characters
        //----------------------------------------------------------------------------
        database.Sort(delegate(Character c1, Character c2) {return c1.chance.CompareTo(c2.chance);});
        float remainingChance = 1f - totalRolled;
        float chance = 0f;

        for (int i = ownedCount; i < database.Count; ++i)
        {
            float actualChance = database[i].GetMasterChance() / remainingChance;
            chance += actualChance;
            database[i].UpdateChance(chance, actualChance);
        }

        database.Sort(delegate(Character c1, Character c2) {return c1.chance.CompareTo(c2.chance);});
    }

    //----------------------------------------------------
    // checks if any characters have not been rolled yet
    //----------------------------------------------------
    public bool CheckUnrolled()
    {
        foreach(var character in database)
        {
            if (!character.owned)
            {
                return false;
            }
        }
        return true;
    }

    //-------------------------
    // for debugging purposes
    //-------------------------
    private void PrintDatabase()
    {
        foreach (var chars in database)
        {
            Debug.Log((chars.id + 1) + "/" + chars.name + "/" + chars.owned + "/ Master Chance: " + chars.GetMasterChance() + "/ Actual Chance: " + chars.actualChance + "/ Chance: " + chars.chance);
        }
        Debug.Log("----------");
    }
}
