using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	CharacterController characterController;

	public float movementSpeed = 6f;
	public float jumpSpeed = 3f;
	public float gravity = 10f;
	
	private Vector3 movementVector = Vector3.zero;
	
		
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(characterController.isGrounded){
			movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			movementVector = transform.TransformDirection(movementVector);
			movementVector *= movementSpeed;
			if(Input.GetButton ("Jump"))
				movementVector.y = jumpSpeed;
			
		}
		movementVector.y -= gravity*Time.deltaTime;
		
		characterController.Move(movementVector*Time.deltaTime);
	}
}
