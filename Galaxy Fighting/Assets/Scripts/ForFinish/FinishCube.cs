using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCube : MonoBehaviour
{
    public Keys keys;
    public GameObject winPanel;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip clip;

   

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        keys = GameObject.Find("KeyFolder").GetComponent<Keys>();
        winPanel.SetActive(false);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(keys.keys >= 4)
            {
                winPanel.SetActive(true);
                
            }
        }
    }
}
