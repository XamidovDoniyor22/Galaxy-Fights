using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int speed;
    public Transform rotate;

    private void Start()
    {
        rotate = GetComponent<Transform>();
    }

    private void Update()
    {
        rotate.Rotate(0, speed * Time.deltaTime, 0);
    }
}
