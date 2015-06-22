using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class SpinRite : MonoBehaviour {
	// __ prefix = order 2 tensor. _ = order 1. no underscore = scalar.
	private Matrix4x4 __localI; // Introduced in “Newton’s Laws Of Rotation”
	private Vector3 _globalL;

	private Rigidbody rigidBody;
	
	void Start() {
		// This creates the diagonalised inertia tensor matrix from the Vector3 by the physics engine.
		// Note the physics engine is using the colliders of the object and it's children, and
		// the mass of the parent object to calculate an approximate inertia tensor.
		rigidBody = GetComponent <Rigidbody> ();
		__localI = Matrix4x4.Scale (rigidBody.inertiaTensor);
		_globalL = __localI * rigidBody.angularVelocity * 0.1f;
	}

	void FixedUpdate() {
		CalculateRotation ();
	}

	void CalculateRotation ()
	{
		// Rotation matrix from world axis, to current object axis.
		Matrix4x4 __rotationMatrix = Matrix4x4.TRS (Vector3.zero, transform.rotation, Vector3.one);

		// Transform inertia tensor from local to global (L' = R _I R^-1).
		Matrix4x4 __globalI =  __rotationMatrix * __localI * __rotationMatrix.inverse;

		// Calculate angular velocity by multiplying inverse (L = I w ==> w = I^-1 L)
		Vector3 _globalW = __globalI.inverse * _globalL;
	
		Vector3 _globalRotationAxis = 	_globalW.normalized;
		float speed = 					_globalW.magnitude;

		float degreesThisFrame = speed * Time.deltaTime * Mathf.Rad2Deg;
		transform.RotateAround (transform.position, _globalRotationAxis, degreesThisFrame);
	}
}