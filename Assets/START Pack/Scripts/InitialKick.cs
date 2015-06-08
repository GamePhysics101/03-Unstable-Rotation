using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class InitialKick : MonoBehaviour {

	public Vector3 initialKick = new Vector3 (4f, 0, 0);

	private Rigidbody rigidBody;
	
	// Use this for initialization
	void OnEnable () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.angularVelocity = initialKick;
	}
}