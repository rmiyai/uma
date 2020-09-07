using UnityEngine;
using System.Collections;

public class OnCollision : MonoBehaviour {
	//public AudioClip hitSe;
	//AudioSource seAudio;
	GameObject obj;
	public GameObject Player;


	// Use this for initialization
	void Start () {
		//seAudio = gameObject.AddComponent<AudioSource> ();
		//seAudio.clip = hitSe;
		//seAudio.loop = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		//Debug.Log (hit.gameObject.tag);
		if (hit.gameObject.tag == "Enemy") {
			obj = hit.gameObject;
			Vector3 player = Player.transform.forward;
			//obj = hit.gameObject;
			obj.rigidbody.AddForce(player.x * 10000, 5000, player.z * 10000);
			obj.rigidbody.AddTorque(10000,10000,10000);
			//seAudio.Play ();
			obj.SendMessage("Explode");
			Invoke ("Explode",5);
				}


	}
	void Explode(){
		obj.SendMessage ("Explode");
		Destroy (obj, 3f);
		}
	
}




