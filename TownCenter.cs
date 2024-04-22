using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCenter : Building
{
    public TownCenter() : base("TownCenter")
    {
        // Setup cost and prerequisites for TownCenter
        Cost[ResourceType.Wood] = 100; // Example cost
        // No prerequisites for TownCenter
    }

    public override void OnBuilt()
    {
        // Implement logic to handle what happens when a TownCenter is built
    }

    public override void OnDestroyed()
    {
        // Implement logic to handle what happens when a TownCenter is destroyed
    }

    // Specific TownCenter methods...
}
