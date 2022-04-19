using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] alien;
    public Vector3[] spawn;

    private float startDelay = 2;
    private float spawnInterval = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPoint", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    async void spawnPoint ()
    {
        int alienIndex = Random.Range(0, alien.Length);
        int spawnIndex = Random.Range(0, spawn.Length);
        Instantiate(alien[alienIndex], spawn[spawnIndex], transform.rotation);
    }

}
