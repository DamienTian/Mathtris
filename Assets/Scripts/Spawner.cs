using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Different shapes of blocks
    [SerializeField] public GameObject[] shapes;

    // Spawn the next blocks into the game surface
    public void SpawnNext() 
    {
        int randomIndex = Random.Range(0, shapes.Length);

        Instantiate(shapes[randomIndex],
                    transform.position,
                    Quaternion.identity);
    }

    void Start()
    {
        SpawnNext();
    }
}
