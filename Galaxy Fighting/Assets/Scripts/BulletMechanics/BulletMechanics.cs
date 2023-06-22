using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    [SerializeField] private int speed = 45;
    [SerializeField] private int distance = 45;

    
    private void Update()
    {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
