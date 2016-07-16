using UnityEngine;
using System.Collections;

public class playerAgua : MonoBehaviour {

	private Animator animator;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;

	private bool goingRight = true;
	private bool enAgua = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent <BoxCollider2D> ();
		rb2D = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//animator.CrossFade ("playerTierraWalk", 0);
		bool trigger = false;
		int horizontal = (int)Input.GetAxisRaw ("Horizontal");
		if (enAgua == true) {
			rb2D.gravityScale = 0.45f;

			if (horizontal > 0) {
				animator.SetTrigger ("playerAguaSwim");
				if (goingRight != true) {
					animator.transform.Rotate (0, 180, 0);
					goingRight = true;
				}
			} else if (horizontal < 0) {
				animator.SetTrigger ("playerAguaSwim");
				if (goingRight == true) {
					animator.transform.Rotate (0, 180, 0);
					goingRight = false;
				}
			} else
				animator.CrossFade ("playerAguaIdle", 0);

			if (Input.GetButtonDown ("Jump")) {
				rb2D.AddForce (new Vector2 (0, 3), ForceMode2D.Impulse);
			}
		} else {
			rb2D.gravityScale = 1;

			if (horizontal > 0) {
				animator.SetTrigger ("playerAguaWalk");
				if (goingRight != true) {
					animator.transform.Rotate (0, 180, 0);
					goingRight = true;
				}
			} else if (horizontal < 0) {
				animator.SetTrigger ("playerAguaWalk");
				if (goingRight == true) {
					animator.transform.Rotate (0, 180, 0);
					goingRight = false;
				}
			} else
				animator.CrossFade ("playerAguaIdle", 0);

			if (Input.GetButtonDown ("Jump") && rb2D.velocity.y == 0) {
				rb2D.AddForce (new Vector2 (0, 1), ForceMode2D.Impulse);
			}
		}

		Vector3 move = new Vector3 (horizontal, 0, 0)/25;  
		transform.position = transform.position + move;
	}

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Water") {
			enAgua = true;
		}
	}
*/
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Water") {
			enAgua = false;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Spikes") {
			Die ();
		} else if (other.gameObject.tag == "Switch") {
			other.gameObject.SendMessage ("onActivated");
		} else if (other.gameObject.tag == "Water" && enAgua == false) {
			enAgua = true;
		}
	}

	void Die() {
		this.gameObject.SetActive (false);
		 //Llama a la pantalla de muerte.
	}
}
