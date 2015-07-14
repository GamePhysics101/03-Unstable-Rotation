using UnityEngine;
using System.Collections;

public class Torque : MonoBehaviour {

	public Vector3 torque;
	public float torqueTime;

	private Rigidbody rigidBody;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if (torqueTime >= 0f) {
			rigidBody.AddTorque (torque);
			torqueTime -= Time.deltaTime;
		}
	}
}
