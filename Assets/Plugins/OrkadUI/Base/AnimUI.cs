using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public abstract class AnimUI : MonoBehaviour {
	//Prop
	public RectTransform rectTransform{get{return GetComponent<RectTransform>();}}
	public float transitionDuration = 0.2f;
	public bool startHidden = true;
	public abstract void Show();
	public abstract void Hide();
}
