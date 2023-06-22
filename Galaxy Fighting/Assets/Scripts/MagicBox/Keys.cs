using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public int keys;
    public KeyaUI ui;

    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip winClip;

    public GameObject arrow;



    private void Start()
    {
        arrow.SetActive(false);
        ui = GameObject.FindGameObjectWithTag("KeyFolderUI").GetComponent<KeyaUI>();
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
    private void Update()
    {
        KeyChecker();
    }
    public void KeyCount()
    {
        int i = 1;
        keys++;
        ui.keyImages[(i * keys) - 1].SetActive(true);
        audioSource.PlayOneShot(clip);     
    }
    private void KeyChecker()
    {
        if(keys >= 4)
        {
            arrow.SetActive(true);
        }
    }
 

}
