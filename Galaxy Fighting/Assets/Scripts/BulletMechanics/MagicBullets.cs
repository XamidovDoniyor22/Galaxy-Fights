using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullets : MonoBehaviour
{
    [Header("SoundSettings")]
    public AudioSource audioSource;
    public AudioClip audio;

    public enum MagicBalls
    {
        bomb = 0,
        hammer = 2,
        shield = 3
    }
    public MagicBalls mBalls;
    public BulletCountMechanism count;

    private void Start()
    {
        count = GameObject.FindGameObjectWithTag("Player").GetComponent<BulletCountMechanism>();
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
       if(mBalls == MagicBalls.bomb)
        {
            if(other.gameObject.tag == "Player")
            {
                count.BombNumber();
                audioSource.PlayOneShot(audio);
                Destroy(gameObject);
            }
        }
       
       if(mBalls == MagicBalls.hammer)
        {
            if(other.gameObject.tag == "Player")
            {
                count.HammerCount();
                audioSource.PlayOneShot(audio);
                Destroy(gameObject);
            }
        }
       if(mBalls == MagicBalls.shield)
        {
            if(other.gameObject.tag == "Player")
            {
                count.ShieldCount();
                audioSource.PlayOneShot(audio);
                Destroy(gameObject);
            }
        }
    }
}

