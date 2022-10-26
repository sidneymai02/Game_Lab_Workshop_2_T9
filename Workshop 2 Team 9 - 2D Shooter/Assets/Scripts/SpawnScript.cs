using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{   
    public GameObject spawnObject;

    void Start()
    {
        StartCoroutine(PowerUpSpawn());
    }

    IEnumerator PowerUpSpawn()
    {
        while (true)
        {
            Vector3 PowerUpPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f,4f), 0f);
            Instantiate(spawnObject, PowerUpPosition, Quaternion.identity);
            yield return new WaitForSeconds(30);
        }
    }
}
