using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shrine : MonoBehaviour
{
	public bool backtoworld = false;
	public string srnetload;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			
			if (backtoworld)
			{
				SceneManager.LoadScene("SampleScene");
			}
			else
			{
				CommonStatus.lastPosition = other.transform.position-Vector3.forward*2;
				SceneManager.LoadScene(srnetload);
			}
		    
		}
	}
}
