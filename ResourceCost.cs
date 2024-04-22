using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceCost
{
    public int gold;
    public int food;
    public int iron;
    public int stone;

    public ResourceCost(int gold = 0, int food = 0, int iron = 0, int stone = 0)
    {
        this.gold = gold;
        this.food = food;
        this.iron = iron;
        this.stone = stone;
    }

    // Add any methods you might need to add, subtract, compare costs, etc.
}

