using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    public GameObject laserpoint;
	public Animator anim;
    void Update()
    {
        //inputs de teclado

        if (Input.GetKey(KeyCode.Alpha1)) indexWeapon = 0;
        if (Input.GetKey(KeyCode.Alpha2)) indexWeapon = 1;
        if (Input.GetKey(KeyCode.Alpha3)) indexWeapon = 2;
		//se aperta tiro instancia o prefab
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			//instancia o objeto e guarda a referencia
			anim.SetTrigger("Skill");
			StartCoroutine(Timer());		
		}
		IEnumerator Timer()
		{
			yield return new WaitForSeconds(0.5f);
			Vector3 tempPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			GameObject myprojectile =
			Instantiate(projectilesPrefab[indexWeapon], tempPos + transform.forward,
			transform.rotation);
			myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);

		}


	}


   

}
