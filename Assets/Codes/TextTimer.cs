using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
	public GameObject inimigos;
	public float time = 5;
    void Start()
    {
		StartCoroutine(TextTime());
    }
	IEnumerator TextTime()
	{
		inimigos.SetActive(true);
		yield return new WaitForSeconds(time);
		inimigos.SetActive(false);
	}
}
