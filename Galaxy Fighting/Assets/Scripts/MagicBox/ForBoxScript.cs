using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBoxScript : MonoBehaviour
{
    public ParticleSystem explosion;

    public GameObject key;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hammer")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(key, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }
}
