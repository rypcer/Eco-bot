using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public Vector2Int movementDirection { get; private set; }
    public int garbageMovedIndex { get; private set; }
    public bool plantCollected { get; private set; }

    public Move(Vector2Int direction, int _garbageMovedIndex, bool _plantCollected )
    {
        movementDirection = direction;
        garbageMovedIndex = _garbageMovedIndex;
        plantCollected = _plantCollected;
    }
}
