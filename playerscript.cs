using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerscript : MonoBehaviour
{
    public int health = 3;
    public float speed = 3;
    public float speedmultiplierforspeedbonus = 2;
    public float horizontalInput;
    public float verticalInput;
    public float fireRate = 0.02f;
    public float nextFire = 0;

    public bool istripleshotactive = false;
    public GameObject tripleshotprefab;

    public bool isspeedactive = false;
    public GameObject speedprefab;

    public bool isshieldactive = false;
    public GameObject shieldprefab;

    spawnmanagerscript spawnmanagerscript;

    public GameObject laserPrefab;

    public GameObject shield;
    public GameObject gameover;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Time.timeScale = 1f;
    }


    void Update()
    {
        CalculateMovement();
        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            if (!istripleshotactive)
            {
                Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(tripleshotprefab, new Vector3(transform.position.x   , transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            }
            nextFire = Time.time + fireRate;
        }
    }



    void CalculateMovement()
    {


        if (transform.position.x < 5 && transform.position.x > -5 && transform.position.y < 4 && transform.position.y > -1)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(direction * Time.deltaTime * speed);
        }
        else
        {
            if (transform.position.x > 5)
            {
                transform.position = new Vector3(4.99f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -5)
            {
                transform.position = new Vector3(-4.99f, transform.position.y, transform.position.z);
            }
            if (transform.position.y > 4)
            {
                transform.position = new Vector3(transform.position.x, 3.99f, transform.position.z);
            }
            if (transform.position.y < -1)
            {
                transform.position = new Vector3(transform.position.x, -0.99f, transform.position.z);
            }
        }
    }

    public void GetDamage()
    {
        if (isshieldactive == true)
        {
            isshieldactive = false;
            shield.SetActive(false);
        }

        else
        {
            health--;
            if (health <= 0)
            {
                Destroy(this.gameObject);
                Time.timeScale = 0f;
                spawnmanagerscript.OnPlayerDeath();
            }
        }
    }

    public void activatetripleshot()
    {
        istripleshotactive = true;

        StartCoroutine(tripleshotbonusbreak());
    }

    IEnumerator tripleshotbonusbreak()
    {
        yield return new WaitForSeconds(5);
        istripleshotactive = false;
    }

    public void activatespeed()
    {
        isspeedactive = true;
        speed *= speedmultiplierforspeedbonus;

        StartCoroutine(speedbonusbreak());
    }

    IEnumerator speedbonusbreak()
    {
        yield return new WaitForSeconds(5);
        isspeedactive = false;
        speed /= speedmultiplierforspeedbonus;
    }

    public void activateshield()
    {
        isshieldactive = true;
        shield.SetActive(true);

        StartCoroutine(shieldbonusbreak());
    }

    IEnumerator shieldbonusbreak()
    {
        yield return new WaitForSeconds(5);
        shield.SetActive(false);
        isshieldactive = false;
    }
}
