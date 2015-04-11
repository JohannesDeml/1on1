using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	public Transform target;
	private Vector3 positionDistance;
	public Vector3 deltaPositionFromPlayer;
	public float damping = 1;
	void Start() {
		//target = GameObject.FindGameObjectWithTag("Player").transform;
		//deltaPositionFromPlayer = transform.position - target.position;
		//deltaPositionFromPlayer = transform.position;
		positionDistance = deltaPositionFromPlayer;
	}

	void LateUpdate() {
		if(target != null) {
			float currentAngle = transform.eulerAngles.y;
			float desiredAngle = target.transform.eulerAngles.y;
			if(currentAngle != desiredAngle) {
				float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
				
				transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, angle, 0);
				positionDistance = RotatePointAroundPivot(deltaPositionFromPlayer, Vector3.zero, Vector3.up*target.eulerAngles.y);
			}
			transform.position = Vector3.Lerp(transform.position, target.position + positionDistance, Time.deltaTime*damping);
			//transform.position = target.position + positionDistance;
		}
	}

	private Vector3 RotatePointAroundPivot(Vector3 point , Vector3 pivot, Vector3 angles) {
		Vector3 dir = point - pivot; // get point direction relative to pivot
		dir = Quaternion.Euler(angles) * dir; // rotate it
		point = dir + pivot; // calculate rotated point
		return point; // return it
	}

	public void SetTarget(Transform newTarget) {
		target = newTarget;
		transform.rotation = target.rotation;
		transform.Rotate(Vector3.left, -20.0f);
	}
}
