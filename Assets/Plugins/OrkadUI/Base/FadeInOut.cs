using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInOut : AnimUI {
	protected CanvasGroup canvasGroup{get{return GetComponent<CanvasGroup>();}}
	private bool show = false;
	public UnityEvent OnShow;
	public UnityEvent OnHide;

	void Start(){
		if(startHidden)
			canvasGroup.alpha = 0f;
		else{
			canvasGroup.alpha = 1f;
			show = true;
		}

	}

	void Update(){
		if(show){
			canvasGroup.alpha +=  Time.deltaTime / transitionDuration;
		}
		else
			canvasGroup.alpha -=  Time.deltaTime / transitionDuration;
		canvasGroup.blocksRaycasts = canvasGroup.interactable = Shown();
		canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);
	}
	
	public override void Show(){
		show = true;
		OnShow.Invoke();
	}
	
	public override void Hide(){
		show = false;
		OnHide.Invoke();
	}
	
	public void Toogle(){
		if(Shown())
			Hide();
		else
			Show();
	}
	
	public bool Hidden(){
		return canvasGroup.alpha == 0f;
	}
	
	public bool Shown(){
		return canvasGroup.alpha == 1f;
	}
}