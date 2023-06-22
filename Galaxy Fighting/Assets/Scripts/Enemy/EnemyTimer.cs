using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimer : MonoBehaviour
{
    private int deathTime = 15;


    private void Start()
    {
        Destroy(gameObject, deathTime);
    }
}
