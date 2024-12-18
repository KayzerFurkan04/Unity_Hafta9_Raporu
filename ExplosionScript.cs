using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }

    void Update()
    {
        
    }
}
