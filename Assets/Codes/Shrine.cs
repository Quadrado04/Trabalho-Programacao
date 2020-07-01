using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shrine : MonoBehaviour
{
	public string srnetload;
	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene(srnetload);
	}
}
