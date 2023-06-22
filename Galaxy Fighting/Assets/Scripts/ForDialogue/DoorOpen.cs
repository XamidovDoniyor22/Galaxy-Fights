using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] public GameObject DoorPanel;

    private void Start()
    {
        DoorPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DoorPanel.SetActive(true);
        }
    }
}
