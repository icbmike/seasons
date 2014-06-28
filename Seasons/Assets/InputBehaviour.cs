using UnityEngine;
using System.Collections;

public class InputBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var jumpButton = Input.GetButton ("Jump");

		if(jumpButton)
			rigidbody2D.AddForce(Vector2.up * 10);
	}
}
