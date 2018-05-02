using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryBullet : MonoBehaviour 
{
	public float Speed;
	public GameObject bulletGameObject;
	public GameObject PlayerBulletGO; //this is our players bullet prefab
	public GameObject bulletPosition01;
	public Directions Dir;

	private PlayerBullet playerbulletScript;

	Rigidbody2D rbody;
	Animator anim;

	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		playerbulletScript = bulletGameObject.GetComponent<PlayerBullet>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (movement_vector != Vector2.zero) 
		{

			anim.SetBool ("iswalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);
		} 
		else 
		{
			anim.SetBool ("iswalking", false);
		}
			
		rbody.MovePosition (rbody.position + movement_vector * Speed);

		if (movement_vector.x > 0)
			Dir = Directions.Right;
		else if (movement_vector.x < 0)
			Dir = Directions.Left;
		else if (movement_vector.y > 0)
			Dir = Directions.Up;
		else if (movement_vector.y < 0)
			Dir = Directions.Down;
		else if (movement_vector.y > 0 && movement_vector.x > 0)
			Dir = Directions.UpRight;
		else if (movement_vector.y > 0 && movement_vector.x < 0)
			Dir = Directions.UpLeft;
		else if (movement_vector.y < 0 && movement_vector.x < 0)
			Dir = Directions.DownLeft;
		else if (movement_vector.y < 0 && movement_vector.x > 0)
			Dir = Directions.DownRight;

		//fire bullet when the spacebar is pressed
		if (Input.GetKeyDown ("space") && Dir == Directions.Right) 
		{
			AudioSource shoot = GetComponent<AudioSource>();
			shoot.Play();

			//instantiate the first bullet
			GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
			//bullet01.transform.position = bulletPosition01.transform.position; //set the bullet initial postion

			bullet01.GetComponent<PlayerBullet>().xspeed = 5.0f;
		}
	}
}
