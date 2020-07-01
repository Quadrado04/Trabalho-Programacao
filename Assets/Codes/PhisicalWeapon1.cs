using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalWeapon1 : MonoBehaviour
{
	public bool TakeDmg = false;
    private void OnCollisionEnter(Collision collision)
    {
		if(TakeDmg)
        collision.gameObject.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
    }
}
