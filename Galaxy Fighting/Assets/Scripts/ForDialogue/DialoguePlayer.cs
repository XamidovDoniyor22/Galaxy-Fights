using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    [SerializeField] public float walkSpeed;

    [SerializeField]
    private Joystick joystick;

    private void Update()
    {
        float x = joystick.Horizontal;

        transform.Translate(Vector2.left * x * Time.deltaTime);

    }
    //private void Move()
    //{
    //    if(Input.GetKey(KeyCode.D))
    //    {
    //        Forward();
    //    }
    //    if(Input.GetKey(KeyCode.A))
    //    {
    //        Back();
    //    }
    //}
    //private void Forward()
    //{
    //    transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
    //}
    //private void Back()
    //{
    //    transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    //}
}
