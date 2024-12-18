using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    float rotateSpeed = 20f;

    public GameObject explosionPrefab;
    public spawnmanagerscript spawnmanagerscript;

    void Start()
    {
        spawnmanagerscript = GameObject.Find("spawnmanagerscript").GetComponent<spawnmanagerscript>();
        if (spawnmanagerscript == null) Debug.LogError("Asteroid_sc::Start spawnmanagerscript is NULL");
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            spawnmanagerscript.StartSpawning();
            Destroy(this.gameObject);
        }
    }
}
