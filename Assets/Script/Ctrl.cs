using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class Ctrl : MonoBehaviour {
	const float gravity = 9.8F;
	public float speed = 10.0F;
	public float rotateSpeed = 5F;
	Animator animator;
	CharacterController controller;
	Vector3 moveDirection = Vector3.zero;
	
	void Start(){


		animator = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	void Update() {

		attachMove ();
		anim ();
		checkOutOfField ();


	}
	void anim(){

		if (CrossPlatformInputManager.GetAxis ("Vertical") > 0.8) {
			speed = 30;
		}
		/*
		if (Input.GetKeyUp ("left shift")) {
			speed = 10;
		}
		*/
		
		
		if (CrossPlatformInputManager.GetAxis ("Vertical") > 0.8) 
		{
			//speed = 0.5F;
			animator.SetBool ("isRun", true);
			animator.SetBool ("isWalk", false);
		} else if(CrossPlatformInputManager.GetAxis ("Vertical") < 0.8){
			//speed = 0.2F;
			animator.SetBool ("isRun", false);
			animator.SetBool ("isWalk", true);
		}
		if (CrossPlatformInputManager.GetAxis("Vertical") == 0) {
			animator.SetBool ("isRun", false);
			animator.SetBool ("isWalk", false);
			
		}
		if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 && CrossPlatformInputManager.GetAxis ("Vertical") < 0.8) {
			animator.SetBool ("isWalk", true);
		}
		
	}
	
	void attachMove (){
		if (!checkOutOfField()) {
						moveDirection.y -= gravity * Time.deltaTime * 10;
						controller.Move (moveDirection * Time.deltaTime);
				}

		if (controller.isGrounded) {
			//moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			//moveDirection = new Vector3 (0, 0, CrossPlatformInputManager.GetAxis("vertical"));
			float x = CrossPlatformInputManager.GetAxis("Horizontal");
			float z = CrossPlatformInputManager.GetAxis("Vertical");
			moveDirection = new Vector3(0 , 0 , z);
			moveDirection = transform.TransformDirection (moveDirection); 
			moveDirection *= speed;  
			//transform.Rotate (0, Input.GetAxis ("Horizontal"), 0);
			transform.Rotate (0, CrossPlatformInputManager.GetAxis("Horizontal"), 0);
		}
	}

	bool checkOutOfField(){
		if (transform.position.y < -100.0f) {
			controller.gameObject.SendMessage("Explode");
			Invoke ("returnStart",2);
			return true;
				}
		return false;
	}

	void returnStart(){
		Application.LoadLevel(Application.loadedLevelName);
	}

}

