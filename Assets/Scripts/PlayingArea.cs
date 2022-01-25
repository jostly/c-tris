using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingArea : MonoBehaviour
{
    [Min(1)]
    public int width = 10;

    [Min(1)]
    public int height = 20;

    public GameObject borderPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var x = 0; x < width; x++)
        {
            var o = Instantiate(borderPrefab, transform);
            o.transform.position = new Vector3(x, 0, 0);
        }

        for (var y = 0; y < height; y++)
        {
            var o = Instantiate(borderPrefab, transform);
            o.transform.position = new Vector3(-1, y, 0);

            o = Instantiate(borderPrefab, transform);
            o.transform.position = new Vector3(width, y, 0);
        }

        transform.position = new Vector3(-width / 2f + 0.5f, -0.5f, 0.5f);
    }

}
