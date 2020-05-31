using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    public GameObject laserpoint;
    void Update()
    {
        //inputs de teclado

        if (Input.GetKey(KeyCode.Alpha1)) indexWeapon = 0;
        if (Input.GetKey(KeyCode.Alpha2)) indexWeapon = 1;
        if (Input.GetKey(KeyCode.Alpha3)) indexWeapon = 2;
		//se aperta tiro instancia o prefab
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			Debug.Log("asda");
			//instancia o objeto e guarda a referencia
			GameObject myprojectile =
			Instantiate(projectilesPrefab[indexWeapon], transform.position + transform.forward,
			transform.rotation);

		}
        
    }


   

}
