using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysUnlockingScript : MonoBehaviour
{
    public Keys key;


    public KeyaUI keyUI;
    private void Start()
    {
        key = GameObject.FindGameObjectWithTag("KeyFolder").GetComponent<Keys>();
        keyUI = GameObject.FindGameObjectWithTag("KeyFolderUI").GetComponent<KeyaUI>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            key.KeyCount();
          
            Destroy(gameObject);
        }
    }
  
}
