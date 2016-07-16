using UnityEngine;
//using System;
using System.Collections;

public class huevo : MonoBehaviour {


	private Animator animator;
    public static bool CheckpointActive = false;
    public static Vector2 checkpoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CheckpointActive = true;
            checkpoint = (Vector2)other.transform.localPosition;
        }
    }

	void animationRespawn() {
		animator.SetTrigger ("nidoRespawn");
	}

    // Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	    
	}
	
	// Update is called once per frame
	void Update () {

	}
}
