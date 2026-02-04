using UnityEngine;
using System.Collections.Generic;

public class DuckManager : MonoBehaviour
{
    [SerializeField]
    GameObject duckPrefab;
    float startX = -10.3f;
    float startY = 2.75f;
    int duckSpeed;
    Dictionary<GameObject, int> ducks = new Dictionary<GameObject, int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            ducks.Add(Instantiate(duckPrefab, new Vector2(startX, startY - i), Quaternion.identity), Random.Range(3, 8));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var duck in ducks)
        {
            ducks.TryGetValue(duck.Key, out duckSpeed);
            duck.Key.transform.Translate(Vector2.right * Time.deltaTime * duckSpeed);
        }
    }
}
