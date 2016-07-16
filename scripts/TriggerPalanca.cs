using UnityEngine;
using System.Collections;

public class TriggerPalanca : MonoBehaviour {

    public PalancaController palancaController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            palancaController.onActivated();
        }
	}
}
