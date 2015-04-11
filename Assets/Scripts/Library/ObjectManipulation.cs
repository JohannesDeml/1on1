using UnityEngine;
using System.Collections;

public class ObjectManipulation : MonoBehaviour {
	
	public void CreateObject(GameObject objectToCreate) {
		Instantiate(objectToCreate);
	}

	public void DestroyObject(GameObject objectToDestroy) {
		Destroy(objectToDestroy);
	}

	public void MoveInXDirection(float deltaX) {
		Move (new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z), 0.5f);
	}

	public void MovetoObject(GameObject target) {
		gameObject.transform.position = target.transform.position;
		Debug.Log("HI");
		//Move(target.transform.position, 0.5f);
	}

	private void Move(Vector3 targetPosition, float duration) {
		iTween.MoveTo(gameObject, new Vector3(targetPosition.x, targetPosition.y, targetPosition.z), duration);
	}
}
