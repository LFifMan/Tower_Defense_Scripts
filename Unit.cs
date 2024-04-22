using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{
    public abstract ResourceCost Cost { get; }
    public GameObject UnitPrefab { get; protected set; }
    public abstract bool CanBePurchased(ResourceManager resourceManager);
    public abstract void Purchase();
    public abstract void Sell();
}
