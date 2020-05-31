using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageControl : MonoBehaviour
{
    public int lifes = 3;
    public IAWalk iawalk;
	public SkinnedMeshRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        iawalk.currentState = IAWalk.IaState.Damage;
		lifes--;
		if (lifes <= 0)
		{
			iawalk.currentState = IAWalk.IaState.Dying;
		}
		StartCoroutine(Blink());

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectiles"))
        {
            lifes--;
            iawalk.currentState = IAWalk.IaState.Damage;
        }
        if (lifes < 0)
        {
            iawalk.currentState = IAWalk.IaState.Dying;
          
        }
    }
	IEnumerator Blink()
	{
		int blinks = 6;
		while (blinks > 0)
		{
			render.enabled = !render.enabled;
			yield return new WaitForSeconds(0.1f);
			blinks--;
		}
	}

}
