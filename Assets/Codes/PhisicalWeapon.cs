using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalWeapon : MonoBehaviour
{
	public bool TakeDmg = false;
    private void OnCollisionEnter(Collision collision)
    {
		if(TakeDmg)
        collision.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
    }
}

