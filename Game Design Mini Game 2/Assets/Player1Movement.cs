using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour 
{
	CharacterController P1ctrl;
	private GameObject P1;

	CharacterController P2ctrl;
	private GameObject P2;

	private float timerOffset;
	private bool isMovingR = false;
	private bool isMovingL = false;
	private Vector3 moveL = new Vector3 (-5, 0, 0);
	private Vector3 moveR = new Vector3 (5, 0, 0);

	private float dist; 

	public float speed = 0.5f;

	void Start () 
	{

		P1 = GameObject.FindWithTag ("Player1");
		P1ctrl = P1.GetComponent<CharacterController>();

		P2 = GameObject.FindWithTag ("Player2");
		P2ctrl = P2.GetComponent<CharacterController>();

		dist = 2;
	}
	

	void FixedUpdate () 
	{
		//Debug.Log(isMovingR);
		if(isMovingR || isMovingL)
		{
			playerMove();
		}

		else if(!isMovingR || !isMovingL)
		{
			TimerReset();
		}

		if(Input.GetKey("d") && !isMovingL)
		{

			isMovingR = true;

		}
		if(Input.GetKey("a")&& !isMovingR)
		{
			isMovingL = true;

		}
	}

	void playerMove()
	{
		if(isMovingR)
		{
			float vel = dist/(Time.time - timerOffset);
			P1.rigidbody.velocity = new Vector3(vel,0,0);
//			P1.transform.position = Vector3.Lerp (P1.transform.position, moveR,(Time.time - timerOffset) * speed);
//			//P1.transform.position = Vector3.Lerp (P1.transform.position, moveR,0.4f);
			if(P1.transform.position.x >= moveR.x)
			{
				P1.rigidbody.velocity = new Vector3(0,0,0);
				isMovingR = false;
				 

			}
		}

		if(isMovingL)
		{
			float vel = dist/(Time.time - timerOffset);
			P1.rigidbody.velocity = new Vector3(-vel,0,0);
			//P1.transform.position = Vector3.Lerp (P1.transform.position,  moveL,(Time.time - timerOffset) * speed);
			if(P1.transform.position.x <= moveL.x)
			{
				P1.rigidbody.velocity = new Vector3(0,0,0);
				isMovingL = false;
			}
		}

	}	

	void TimerReset()
	{
		timerOffset = Time.time;
	}
}