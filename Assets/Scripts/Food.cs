using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] 
    private GameObject innerWalls;
    [SerializeField] 
    private BoxCollider gridArea;
    public static Food Instance { get; set; }
    private void Start()
    {
        Instance = this;
        Spawn();
    }
    public void Spawn()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        var colliders = innerWalls.GetComponentsInChildren<BoxCollider>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].bounds.Contains(this.transform.position))
                Spawn();
        }
    }
    
}
