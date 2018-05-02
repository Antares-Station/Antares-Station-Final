using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myrigidbody;

	private bool moving;//Update-Checker for movement

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 moveDirection;//Update-random direction to move

	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

	void Start () 
	{
		myrigidbody = GetComponent<Rigidbody2D> ();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}


	void Update () 
	{
		if (moving) 
		{
			timeToMoveCounter -= Time.deltaTime;
			myrigidbody.velocity = moveDirection;

			if (timeBetweenMoveCounter < 0f) 
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		} 

		else 
		{
			timeBetweenMoveCounter -= Time.deltaTime;
			myrigidbody.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0f) 
			{
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3(Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			}
		}

		if (reloading) 
		{
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) 
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				thePlayer.SetActive (true);
			}

		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		/* if (other.gameObject.name == "Character") 
		{
			other.gameObject.SetActive (false);
			reloading = true;
			thePlayer = other.gameObject;
		} */
	}

}