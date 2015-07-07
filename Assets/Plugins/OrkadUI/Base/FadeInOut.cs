using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup),typeof(RectTransform))]
public class FadeInOut : MonoBehaviour{
	//Properties
	protected CanvasGroup canvasGroup{get{return GetComponent<CanvasGroup>();}}
	protected RectTransform rectTransform{get{return GetComponent<RectTransform>();}}
	public bool shown {get {return canvasGroup.alpha == 1f;}}
	public bool hidden{get{return canvasGroup.alpha == 0f;}}



	//Variables
	public float transitionDuration = 0.2f;
	public bool showing = false;

	void Update(){
		if(showing)
			canvasGroup.alpha += Time.deltaTime / transitionDuration;
		else
			canvasGroup.alpha -= Time.deltaTime / transitionDuration;
		Mathf.Clamp01(canvasGroup.alpha);
		canvasGroup.blocksRaycasts = canvasGroup.interactable = shown;
	}

	public void Show ()
	{
		showing = true;
	}

	public void Hide (){
		showing = false;
	}
}