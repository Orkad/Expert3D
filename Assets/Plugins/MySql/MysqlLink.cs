//UNITYENGINE
using UnityEngine;
using UnityEngine.Events;
//.NET 2.0
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
//MYSQL
using MySql.Data;
using MySql.Data.MySqlClient; 

public class MysqlLink : MonoBehaviour {
	public string host = "localhost";
	public int port = 3306;
	public string user = "root";
	public string password = "";
	public string dbname = "Unity";
	public MySqlConnection connection;

	void Awake(){
		connection = new MySqlConnection("server=" + host + ";port=" + port.ToString() + ";user=" + user + ";password=" + password + ";database=" + dbname + ";");
	}

	public void Open(){
		try{connection.Open();}
		catch(MySqlException ex){Debug.LogError("Mysql Error : " + ex.Message);}
	}

	public void Close(){
		try{connection.Close();}
		catch(MySqlException ex){Debug.LogError("Mysql Error : " + ex.Message);}
	}
}
