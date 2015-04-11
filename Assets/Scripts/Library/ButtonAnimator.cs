using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonAnimator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler {
	private Animator buttonAnimator;
	private bool pointerIsInside = false;
	private bool buttonDown = false;
	public bool fadeInAtStart = false;
	public float fadeInDelay = 0.0f;

	private AudioSource clickSound;
	// Use this for initialization
	void Start () {
		buttonAnimator = GetComponent<Animator>();
		clickSound = GetComponent<AudioSource>();
		if(fadeInAtStart) {
			buttonAnimator.SetTrigger("GameStarted");
			StartCoroutine(FadeInWithDelay());
		}
	}

	public void OnPointerDown (PointerEventData eventData) {
		buttonAnimator.SetTrigger("ButtonDown");
		pointerIsInside = true;
		buttonDown = true;
	}

	public void OnPointerUp (PointerEventData eventData) {
		if(pointerIsInside && buttonDown) {
			buttonAnimator.SetTrigger("ButtonUp");
			pointerIsInside = false;
		}
		buttonDown = false;
	}

	public void OnPointerExit (PointerEventData eventData) {
		if(buttonDown) {
			buttonAnimator.SetTrigger("ButtonExit");
		}
		pointerIsInside = false;
	}

	public void OnPointerEnter (PointerEventData eventData) {
		pointerIsInside = true;
	}

	public void PlayClickSound() {
		clickSound.Play();
	}

	public IEnumerator FadeInWithDelay() {
		yield return new WaitForSeconds(fadeInDelay);
		buttonAnimator.SetTrigger("FadeIn");
	}
}
