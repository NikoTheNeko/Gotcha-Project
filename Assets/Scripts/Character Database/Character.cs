using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int id; //probably don't need this but eh
    public string name;
    private float masterChance; //kept for calculating future roll chances
    public float chance; //actual chance used when rolling; number used in CharacterDatabase
    public float actualChance; //actual chance used when rolling; actual numerical representation
    public bool owned = false;

    public Character(int _id, string _name, float _masterChance, float _chance)
    {
        id = _id;
        name = _name;
        masterChance = _masterChance;
        chance = _chance;

        actualChance = masterChance;
    }

    //-----------------------
    // disable future rolls
    //-----------------------
    public void DisableRoll()
    {
        chance = 0f;
        actualChance = 0f;
    }

    //-----------------------
    // updates roll chances
    //-----------------------
    public void UpdateChance(float _chance, float _actualChance)
    {
        chance = _chance;
        actualChance = _actualChance;
    }

    public float GetMasterChance()
    {
        return masterChance;
    }
}
