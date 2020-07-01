using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdWalk : MonoBehaviour
{
    public enum States
    {
        idle,
        walk,
        jump,
        die,
        attack,
		Hit,
    }
    public States state;
    public Animator anim;
    public Rigidbody rdb;
	public float jumpforce = 1000;
	float jumptime = .5f;
	public int lifes = 5;
	public bool hitted = false;
	public GameObject panel;
	public GameObject ButtonManager;
	public GameObject inimigos;
	public float time = 5;

	public Vector3 move { get; private set; }
    public float movforce=100;

    Vector3 direction;

    GameObject referenceObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Idle());

        referenceObject=Camera.main.GetComponent<trdCam>().GetRefereceObject();
    }
	

	// Update is called once per frame
	void FixedUpdate()
    {
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = referenceObject.transform.TransformDirection(move);

        //girar pra direcao das teclas
        if (move.magnitude > 0)
        {
            direction = move;
        }
        transform.forward =Vector3.Lerp(transform.forward,direction,Time.fixedDeltaTime*20);

       
        //reduz a força de movimento de acordo com a velocidade pra ter muita força de saida mas pouca velocidade. 
        rdb.AddForce(move * (movforce/(rdb.velocity.magnitude+1)));

		//rdb.AddForce(-rdb.velocity.x * 250, rdb.velocity.y * 2, -rdb.velocity.z * 250);

		Vector3 velocityWoY = new Vector3(rdb.velocity.x, 0, rdb.velocity.z);
		rdb.AddForce(-velocityWoY * 500);


		if (Physics.Raycast(transform.position + Vector3.up * .5f, Vector3.down, out RaycastHit hit, 65279))
		{
			anim.SetFloat("GroundDistance", hit.distance);
		}

	}
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
		if (Input.GetButtonDown("Jump"))
		{
			StartCoroutine(Jump());
		}
		if (Input.GetButtonUp("Jump"))
		{
			jumptime = 0;
		}
	}

    IEnumerator Idle()
    {
        //equivalente ao Start 
        state = States.idle;

        
        //
        while (state == States.idle)
        {
            //equivalente ao update

            anim.SetFloat("Velocity", 0);
            if (rdb.velocity.magnitude > 0.1f)
            {
                StartCoroutine(Walk());
            }
            //
            yield return new WaitForEndOfFrame();
        }
        //saida do estado
    }

    IEnumerator Walk()
    {
        //equivalente ao Start 
        state = States.walk;


        //
        while (state == States.walk)
        {
            //equivalente ao update

            anim.SetFloat("Velocity", rdb.velocity.magnitude);
            if (rdb.velocity.magnitude < 0.1f)
            {
                StartCoroutine(Idle());
            }
            //
            yield return new WaitForEndOfFrame();
        }
        //saida do estado
    }


    IEnumerator Attack()
    {
        //equivalente ao Start 
        state = States.attack;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(.5f);
        //saida do estado
        StartCoroutine(Idle());
    }
	IEnumerator Hit()
	{
		//equivalente ao Start 
		state = States.Hit;
		anim.SetTrigger("Hit");
		lifes--;
		if (lifes <= 0)
		{
			yield return new WaitForEndOfFrame();
			StartCoroutine(Die());

		}
		else
		{
			yield return new WaitForEndOfFrame();
			StartCoroutine(Idle());
		}
	}
	public void TakeDamage()
	{
		if(hitted==false)
		{
			hitted = true;
			StartCoroutine(HitTime());

			StartCoroutine(Hit());

		}

	}
	IEnumerator HitTime()
	{
		yield return new WaitForSeconds(1f);
		hitted = false;
	}

	IEnumerator Jump()
	{
		//equivalente ao Start 
		state = States.jump;
		jumptime = 0.5f;

		if(Physics.Raycast(transform.position+Vector3.up*.5f,Vector3.down,out RaycastHit hit, 65279))
		{
			if (hit.distance > 0.6f)
			{
				StartCoroutine(Idle());
			}
		}
		//
		while (state == States.jump)
		{
			//equivalente ao update
			rdb.AddForce(Vector3.up * jumpforce * jumptime);
			jumptime -= Time.fixedDeltaTime;
			if (jumptime < 0)
			{
				StartCoroutine(Idle());
			}
			yield return new WaitForFixedUpdate();
		}
		//saida do estado
	}
	IEnumerator Die()
	{
		//equivalente ao Start 
		state = States.die;
		anim.SetBool("Die", true);

		yield return new WaitForSeconds(0.5f);

		StartCoroutine(Timer());
		GetComponent<Rigidbody>().isKinematic = true;
		this.enabled = false;
	}
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(2.5f);
		panel.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	


}
