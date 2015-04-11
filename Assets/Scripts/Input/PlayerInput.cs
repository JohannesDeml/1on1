using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public bool moveable = true;
	public float rotateTo = 0.0f;
	public float speed = 2.0f;
	public float jumpStrength = 280.0f;
	public float rotationSpeed = 240.0f;
	private Rigidbody rigidBody;
	private float deltaRotation = 0.0f;
	private int jumpCount = 0;
	private int maxJumps = 1;
	private bool crazyMode = false;
	private Animator anim;
	private float lastRotationInput = 0.0f;
	private float lastJumpInput = 0.0f;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(moveable) {
			//Rotation
			if(Time.time > lastRotationInput + 0.05f) {
				if(Input.GetKeyDown(KeyCode.A)) {
					rotateTo -= 90.0f;
					if(rotateTo < -360.0f) {
						rotateTo += 360;
					}
					lastRotationInput = Time.time;
				}
				if(Input.GetKeyDown(KeyCode.D)) {
					rotateTo += 90.0f;
					if(rotateTo > 360.0f) {
						rotateTo -= 360;
					}
					lastRotationInput = Time.time;
				}
				if(Input.GetKeyDown(KeyCode.S)) {
					rotateTo += 180.0f;
					if(rotateTo >= 360.0f) {
						rotateTo -= 360;
					}
					lastRotationInput = Time.time;
				}
			}

			HandleRotation();

			//Movement
			if(Input.GetKey(KeyCode.W) && deltaRotation <= 10.0f) {
				RaycastHit hit;
				if(!rigidBody.SweepTest(transform.forward, out hit, 0.3f) || jumpCount == 0) {
					rigidBody.AddRelativeForce(Vector3.forward*20.0f*Time.fixedDeltaTime, ForceMode.VelocityChange);
					//rigidBody.MovePosition(transform.position + transform.forward*speed*Time.fixedDeltaTime);
				}
				if(jumpCount == 0) {
					rigidBody.AddForce(Vector3.up*5.0f);
				}

				//Set max speed
				Vector2 groundMovement = new Vector2(rigidBody.velocity.x, rigidBody.velocity.z);
				groundMovement = Vector2.ClampMagnitude(groundMovement, speed);
				rigidBody.velocity = new Vector3(groundMovement.x, rigidBody.velocity.y, groundMovement.y);

			}

			//Jump
			if(Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps) {
				if(Time.time > lastJumpInput + 0.05f) {
					anim.SetTrigger("Jump");
					jumpCount++;
					rigidBody.AddForce(Vector3.up*jumpStrength);
				}
			}

			if(Input.GetKeyDown(KeyCode.Backspace)) {
				crazyMode = !crazyMode;
				if(crazyMode) {
					maxJumps = 8;
				} else {
					maxJumps = 1;
				}
			}
		}
	}

	private void HandleRotation() {
		float newRotation = Mathf.LerpAngle(transform.eulerAngles.y, rotateTo, Time.fixedDeltaTime* 5.0f);
		deltaRotation = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, rotateTo));

		transform.eulerAngles = new Vector3(0.0f, newRotation, 0.0f);
	}

	public void _OnTouchGround() {
		if(jumpCount != 0) {
			anim.SetTrigger("HitGround");
		}
		jumpCount = 0;
	}
}
