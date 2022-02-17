using System;
using UnityEngine;

[Serializable]
public class Shape
{
    public bool[] row1 = new bool[4];
    public bool[] row2 = new bool[4];
    public bool[] row3 = new bool[4];
    public bool[] row4 = new bool[4];

    public bool HasBlockAt(int x, int y)
    {
        switch (y) 
        {
            case 0:
                return row1[x];
            case 1:
                return row2[x];
            case 2:
                return row3[x];
            case 3:
                return row4[x];
        }

        return false;
    }

    public void Rotate()
    {
    }
}