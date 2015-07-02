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

public class Auth:MonoBehaviour{
	public MysqlLink link;
	public InputField usernameField;
	public InputField passwordField;
	public Button connectButton;
	public bool connected;
	public string connectedUser;
	public UnityEvent OnUserConnected;

	void Awake(){
		connectButton.onClick.AddListener(() => TryConnectUser(usernameField.text,passwordField.text));
	}

	private void TryConnectUser(string username,string password){
		link.Open();
		MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE username=@username AND password=PASSWORD(@password)",link.connection);
		cmd.Parameters.AddWithValue("@username",username);
		cmd.Parameters.AddWithValue("@password",password);
		MySqlDataReader rdr = cmd.ExecuteReader();
		if(rdr.HasRows){
			connected = true;
			connectedUser = username;
			Debug.Log("Connecté en tant que " + username);
			OnUserConnected.Invoke();
		}
		else
			Debug.Log("Nom d'utilisateur ou mot de passe incorrect.");
		link.Close();
	}

	public void DisconnectUser(){
		connected = false;
		connectedUser = "";
	}
}