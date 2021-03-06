﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    public int iaCount;
    public List<GameObject> ias;
	public GameObject panel;
	public GameObject ButtonManager;
	public bool over { get; private set; }
    public int inimigos { get; private set; }

    private void Awake()
    {
        inimigos = 0;
    }

    void Start()
    {
        GetAllIA();
    }

    // Update is called once per frame
    void Update()
    {
        VerifyIA();
    }

    void GetAllIA()
    {
        IAWalk[] temp = new IAWalk[iaCount];

        temp = GetComponentsInChildren<IAWalk>();

        for (int i = 0; i < temp.Length; i++)
            ias.Add(temp[i].gameObject);
    }

    void VerifyIA()
    {
        int index = 0;
        inimigos = 0;
        for (int i = 0; i < ias.Count; i++)
        {
            if (ias[i] == null)
                index++;
            else
                inimigos++;
        }

        if (index == iaCount)
        {
            over = true;
            Victory();
        }
        else
            over = false;
    }

    private void Victory()
    {
		Time.timeScale = 1.0f;
		GameObject.FindGameObjectWithTag("Player").GetComponent<TrdWalk>().enabled = false;
		//ButtonManager.SetActive(true);
		StartCoroutine(Timer());
	}
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(3.0f);
		panel.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
