using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitFactory
{
    public static Unit CreateUnit(Type unitType)
    {
        // You can use a switch or if statements here if you have specific logic
        // for different unit types, or continue using reflection as shown below.
        return (Unit)Activator.CreateInstance(unitType);
    }
}
