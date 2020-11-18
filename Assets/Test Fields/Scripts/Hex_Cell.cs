using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Cell : MonoBehaviour
{
    public int width = 6;
    public int height = 6;

    public Hex_Cell hexPrefb;

    Hex_Cell[] Hex_Cells;

    void Awake()
    {
        Hex_Cells = new Hex_Cell[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell (int x, int z, int i)
    {
        Vector3 posit;
        posit.x = x * 10f;
        posit.y = 0F;
        posit.z = z * 10f;

        Hex_Cell cell = Hex_Cells[i] = Instantiate<Hex_Cell>(hexPrefb);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = posit;
    }
}
