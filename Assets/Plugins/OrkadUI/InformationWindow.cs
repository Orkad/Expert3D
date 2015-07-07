using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace OrkadUI{
	[RequireComponent(typeof(FadeSH))]
	public class InformationWindow : MonoBehaviour {
		//Prop
		public FadeSH fadeInOut{get{return GetComponent<FadeSH>();}}
		//Ref
		[Header("References")]
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
}


