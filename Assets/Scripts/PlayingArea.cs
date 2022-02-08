using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingArea : MonoBehaviour
{
    [Min(1)] public int width = 10;

    [Min(1)] public int height = 20;

    public GameObject borderPrefab;

    private bool[,] _grid;

    // Start is called before the first frame update
    void Start()
    {
        _grid = new bool[width, height];

        for (var x = 0; x < width; x++)
        {
            var o = Instantiate(borderPrefab, transform);
            o.transform.localPosition = new Vector3(x, 0, 0);
        }

        for (var y = 0; y < height; y++)
        {
            var o = Instantiate(borderPrefab, transform);
            o.transform.localPosition = new Vector3(-1, y, 0);

            o = Instantiate(borderPrefab, transform);
            o.transform.localPosition = new Vector3(width, y, 0);
        }

        transform.position = new Vector3(-width / 2f, 0, 1);
    }

    public bool CanAddShape(int x, int y, Shape shape)
    {
        return true; // TODO: Kolla om det finns något ivägen för blocket och returnera false i så fall
        // Kolla även om någon del av blocket skulle hamna utanför spelfältet och returnera false i så fall
        // (jämför med metoden SetShape och hur jag kollar om x och y är för stort eller litet)
    }

    public void AddShape(int x, int y, Shape shape)
    {
        SetShape(x,y,shape,true);
    }

    public void RemoveShape(int x, int y, Shape shape)
    {
        SetShape(x, y,shape, false);
    }

    private void SetShape(int baseX, int baseY, Shape shape, bool value)
    {
        for (var ty = 0; ty < 4; ty++)
        {
            var y = baseY + ty;
            if (y < 0 || y >= height)
            {
                continue;
            }

            for (var tx = 0; tx < 4; tx++)
            {
                var x = baseX + tx;
                if (x < 0 || x >= width)
                {
                    continue;
                }

                if (shape.IsBlocked(tx, ty))
                {
                    _grid[x, y] = value;
                }
            }
        }
    }
}