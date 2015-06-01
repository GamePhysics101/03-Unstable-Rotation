using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class InitialKick : MonoBehaviour {

	private Rigidbody rigidBody;
	
	// Use this for initialization
	void OnEnable () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.angularVelocity = new Vector3 (4f, 0, 0);
	}
}