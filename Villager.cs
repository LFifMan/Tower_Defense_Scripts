using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Unit
{
    public override ResourceCost Cost => new ResourceCost(gold: 5, food: 5);

    public Villager() {
        this.UnitPrefab = Resources.Load("VillagerPrefab") as GameObject; // Load the prefab
    }

    public override bool CanBePurchased(ResourceManager resourceManager)
    {
        // Assuming you have methods in ResourceManager to get the current resource amounts.
        return TownCenter.Instance != null &&
            resourceManager.GetGold() >= Cost.gold &&
            resourceManager.GetFood() >= Cost.food &&
            resourceManager.GetIron() >= Cost.iron &&
            resourceManager.GetStone() >= Cost.stone;
    }

    public override void Purchase() {
        // Deduct cost, instantiate villager, assign to resource, etc.
    }

    public override void Sell() {
        // Add back some resources, etc.
    }
}
