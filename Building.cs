using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building
{
    public string Name { get; protected set; }
    public Dictionary<ResourceType, int> Cost { get; protected set; }
    public List<Building> Prerequisites { get; protected set; }

    protected Building(string name)
    {
        Name = name;
        Cost = new Dictionary<ResourceType, int>();
        Prerequisites = new List<Building>();
    }

    public abstract void OnBuilt(); // Called when the building is constructed.
    public abstract void OnDestroyed(); // Called when the building is destroyed.

    // Other common methods and properties...
}
