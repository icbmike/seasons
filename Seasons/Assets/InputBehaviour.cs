using UnityEngine;
using System.Collections;

public class InputBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<PlayerState>();
	}

	void FixedUpdate(){
		var jumpButton = Input.GetButton ("Jump");

	}

	// Update is called once per frame
	void Update () {

	}
}
