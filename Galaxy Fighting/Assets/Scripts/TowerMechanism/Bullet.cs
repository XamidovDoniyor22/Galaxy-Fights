using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform player;
    public float speed = 70f;

    [Header("Sound")]
    public AudioSource audio;
    public AudioClip clip;

    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
    public void Seek(Transform target)
    {
        player = target;
    }
    private void FixedUpdate()
    {
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = player.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    private void HitTarget()
    {
        audio.PlayOneShot(clip);
        Destroy(gameObject, 0.1f);
    }
   
}
