using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{

	private Transform target;
	public float Chasespeed;

	public float movespeed;

	private Rigidbody2D myrigidbody;

	public bool iswalking;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int WalkDirection;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("player").GetComponent<Transform> ();

		myrigidbody = GetComponent<Rigidbody2D> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (iswalking) 
		{
			walkCounter -= Time.deltaTime;

			switch (WalkDirection) 
			{
			case 0:
				myrigidbody.velocity = new Vector2 (0, movespeed);
				break;	

			case 1:
				myrigidbody.velocity = new Vector2 (movespeed, 0);
				break;

			case 2:
				myrigidbody.velocity = new Vector2 (0, -movespeed);
				break;

			case 3:
				myrigidbody.velocity = new Vector2 (-movespeed, 0);
				break;
			}

			if(walkCounter < 0)
			{
				iswalking = false;
				waitCounter = waitTime;
			}

		} 
		else 
		{
			waitCounter -= Time.deltaTime;

			myrigidbody.velocity = Vector2.zero;

			if(waitCounter < 0)
			{
				ChooseDirection();
			}


		}

		if (Vector2.Distance(transform.position, target.position) > 3) 
		{
			myrigidbody.MovePosition(Vector2.MoveTowards(transform.position, target.position, Chasespeed * Time.deltaTime));
			//transform.position = Vector2.MoveTowards(transform.position, target.position, Chasespeed * Time.deltaTime);
		}
	
	}

	public void ChooseDirection()
	{

		WalkDirection = Random.Range (0, 4);

		iswalking = true;
		walkCounter = walkTime;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name == "AlertRadius") 
		{

			transform.position = Vector2.MoveTowards(transform.position, target.position, Chasespeed * Time.deltaTime);
			//myrigidbody.MovePosition(Vector2.MoveTowards(transform.position, target.position, Chasespeed * Time.deltaTime));

		}

	}

}
