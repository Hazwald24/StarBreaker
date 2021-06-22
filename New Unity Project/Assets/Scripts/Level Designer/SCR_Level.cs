using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Level : ScriptableObject
{
    public Vector2Int gridSize;
}

[System.Serializable]
public class LevelSetup
{
    public int[] columns;
}
