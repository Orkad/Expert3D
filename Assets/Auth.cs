//UNITYENGINE
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//.NET 2.0
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
//MYSQL
using MySql.Data;
using MySql.Data.MySqlClient;
//OrkadUI
using OrkadUI;

public class Auth:MonoBehaviour{

	[Header("References")]
	public MysqlLink link;
	public InputField usernameField;
	public InputField passwordField;
	public Button connectButton;
	public InformationWindow informationWindow;
	
	[Header("Variables")]
	public bool connected;
	public string connectedUser;

	[Header("Events")]
	public UnityEvent OnUserConnected;

	void Awake(){
		connectButton.onClick.AddListener(TryConnectUser);
	}

	void TryConnectUser(){
		link.connection.Open();
		MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE username=@username AND password=PASSWORD(@password)",link.connection);
		cmd.Parameters.AddWithValue("@username",usernameField.text);
		cmd.Parameters.AddWithValue("@password",passwordField.text);
		MySqlDataReader rdr = cmd.ExecuteReader();
		if(rdr.HasRows){
			connected = true;
			connectedUser = usernameField.text;
			Debug.Log("Connecté en tant que " + usernameField.text);
			informationWindow.Show("Connexion Réussie","Connecté en tant que " + usernameField.text);
			OnUserConnected.Invoke();
		}
		else
			informationWindow.Show("Erreur de connexion","Nom d'utilisateur ou mot de passe incorrect");
		link.connection.Close();
	}

	public void DisconnectUser(){
		connected = false;
		connectedUser = "";
	}
}