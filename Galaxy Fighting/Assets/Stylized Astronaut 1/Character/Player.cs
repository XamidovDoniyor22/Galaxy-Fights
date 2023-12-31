using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;
	    [SerializeField]
	    private Joystick joystick;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update ()
	    {
		float x = joystick.Horizontal;
		float y = joystick.Vertical;	


			if (x != 0 || y != 0) 
		    {
				anim.SetInteger ("AnimationPar", 1);
			}  
		    else 
		    {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * y * speed;
			}

			float turn = x;
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}
