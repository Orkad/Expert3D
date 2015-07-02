using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(FadeInOut))]
public class InformationWindow : MonoBehaviour {
	//Prop
	public FadeInOut fadeInOut{get{return GetComponent<FadeInOut>();}}
	//Ref
	public Text titleTextRef;
	public Text informationTextRef;
	public Button okButtonRef;

	void Awake(){
		okButtonRef.onClick.AddListener(fadeInOut.Hide);
	}

	public void Show(string title,string information){
		titleTextRef.text = title;
		informationTextRef.text = information;
		fadeInOut.Show();
	}
}
