using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float speed = 3;

    public int bonusýd;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y <= -3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            playerscript playerscript = other.transform.GetComponent<playerscript>();
            if(playerscript != null)
            {
                switch (bonusýd)
                {
                    case 0:
                        {
                            playerscript.activatetripleshot();
                            break;
                        }
                    case 1:
                        {
                            playerscript.activatespeed();
                            break;
                        }
                    case 2:
                        {
                            playerscript.activateshield();
                            break;
                        }
                }
            }

            Destroy(this.gameObject);

        }
    }
}
