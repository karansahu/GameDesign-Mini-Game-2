using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour 
{
	CharacterController P1ctrl;
	private GameObject P1;

	CharacterController P2ctrl;
	private GameObject P2;

	private float timerOffset;
	public float firstDelay;
	private float origTime;

	private bool isMoving = false;

	private Vector3 moveL = Vector3.left * 5;
	private Vector3 moveR = Vector3.right * 5;
	private string dir;

	void Start () 
	{

		P1 = GameObject.FindWithTag ("Player1");
		P1ctrl = P1.GetComponent<CharacterController>();

		P2 = GameObject.FindWithTag ("Player2");
		P2ctrl = P2.GetComponent<CharacterController>();
	}
	

	void Update () 
	{
		if(isMoving)
		{
			playerMove();
		}
		else if(!isMoving)
		{
			TimerReset();
		}

		if(Input.GetKey("d"))
		{

		}
	}

	void playerMove()
	{
		if(DestNum < Destinations.Length)
		{
			P1.transform.position = Vector3.Lerp (P1.transform.position, moveL,(Time.time - timerOffset) * speed);
			delayCheck = true;
		}
	}	

	void TimerReset()
	{
		timerOffset = Time.time;
	}
}