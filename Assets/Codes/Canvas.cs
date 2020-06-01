using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
	public GameObject inimigos;
	public float time = 5;
	public Text lifes;
	public Text enemies;
	private TrdWalk player;
	private IAController enemy;
    void Start()
    {
		StartCoroutine(TextTime());
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<TrdWalk>();
		enemy = GameObject.FindObjectOfType<IAController>();
		
    }
	private void Update()
	{
		lifes.text = "Vidas: " + player.lifes;
		enemies.text = "Inimigos: " + enemy.inimigos;
	}
	IEnumerator TextTime()
	{
		inimigos.SetActive(true);
		yield return new WaitForSeconds(time);
		inimigos.SetActive(false);
	}
}
