using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour 
{
	public int Ammo = 30;
	public float Speed;
	public GameObject bulletGameObject;
	public GameObject PlayerBulletGO; //this is our players bullet prefab
	public GameObject bulletPosition01;
	public Directions Dir;

	private PlayerBullet playerbulletScript;

//	Dash Mechanic
	public DashState dashState;
	public float dashTimer;
	public float maxDash = 2f;

	public float savedSpeed;



	public AudioSource Audio;
	public AudioClip Shoot;
	public AudioClip NoAmmo;

	public static int MoveSpeed = 3;



	public Vector2 savedVelocity;

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
		AmmoManager.AmmoCount (Ammo);

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


		//Dashing
		switch (dashState) 
		{
		case DashState.Ready:
			var isDashKeyDown = Input.GetKeyDown ("z");
			Debug.Log ("Start dashstate ready");
			if (isDashKeyDown) 
			{
				savedSpeed = Speed;
				Speed = Speed + 2;

				dashState = DashState.Dashing;
			}
			break;
		case DashState.Dashing:
			Debug.Log ("Start dashstate dashing");
			dashTimer += Time.deltaTime * 3;
			if(dashTimer >= maxDash)
			{
				dashTimer = maxDash;
				Speed = savedSpeed;
				dashState = DashState.Cooldown;
			}
			break;
		case DashState.Cooldown:
			Debug.Log ("Start dashstate cooldown");
			dashTimer -= Time.deltaTime;
			if(dashTimer <= 0)
			{
				dashTimer = 0;
				dashState = DashState.Ready;
			}
			break;
		}
	
		// Dashing (Controller)

		switch (dashState) 
		{
		case DashState.Ready:
			var isDashKeyDown = Input.GetButtonDown ("Dash");
			Debug.Log ("Start dashstate ready");
			if (isDashKeyDown) 
			{
				savedSpeed = Speed;
				Speed = Speed + 2;

				dashState = DashState.Dashing;
			}
			break;
		case DashState.Dashing:
			Debug.Log ("Start dashstate dashing");
			dashTimer += Time.deltaTime * 3;
			if(dashTimer >= maxDash)
			{
				dashTimer = maxDash;
				Speed = savedSpeed;
				dashState = DashState.Cooldown;
			}
			break;
		case DashState.Cooldown:
			Debug.Log ("Start dashstate cooldown");
			dashTimer -= Time.deltaTime;
			if(dashTimer <= 0)
			{
				dashTimer = 0;
				dashState = DashState.Ready;
			}
			break;
		}


			
		


		//fire bullet when the spacebar is pressed
		if (Input.GetKeyDown ("space") && Dir == Directions.Right) 
		{
			if (Ammo > 0) 
			{
				
				Audio.PlayOneShot(Shoot);

				//instantiate the first bullet
				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				//bullet01.transform.position = bulletPosition01.transform.position; //set the bullet initial postion

				bullet01.GetComponent<PlayerBullet> ().xspeed = 5.0f;

				Ammo= Ammo - 1;
			} 
			else 
			{
				
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetKeyDown ("space") && Dir == Directions.Left) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				//instantiate the first bullet
				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				//bullet01.transform.position = bulletPosition01.transform.position; //set the bullet initial postion

				bullet01.GetComponent<PlayerBullet> ().xspeed = -5.0f;

				Ammo= Ammo - 1;
			} 
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetKeyDown ("space") && Dir == Directions.Up) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().yspeed = 5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetKeyDown ("space") && Dir == Directions.Down) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().yspeed = -5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetKeyDown ("space") && Dir == Directions.UpRight) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = 5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = 5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetKeyDown ("space") && Dir == Directions.UpLeft) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = -5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = 5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetKeyDown ("space") && Dir == Directions.DownRight) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = 5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = -5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetKeyDown ("space") && Dir == Directions.DownLeft) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = -5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = -5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}



		// Controller Input
		if (Input.GetButtonDown ("Fire1") && Dir == Directions.Right) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				//instantiate the first bullet
				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				//bullet01.transform.position = bulletPosition01.transform.position; //set the bullet initial postion

				bullet01.GetComponent<PlayerBullet> ().xspeed = 5.0f;

				Ammo= Ammo - 1;
			} 
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetButtonDown ("Fire1") && Dir == Directions.Left) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				//instantiate the first bullet
				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);
				//bullet01.transform.position = bulletPosition01.transform.position; //set the bullet initial postion

				bullet01.GetComponent<PlayerBullet> ().xspeed = -5.0f;

				Ammo= Ammo - 1;
			} 
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetButtonDown ("Fire1") && Dir == Directions.Up) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().yspeed = 5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetButtonDown ("Fire1") && Dir == Directions.Down) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().yspeed = -5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetButtonDown ("Fire1") && Dir == Directions.UpRight) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = 5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = 5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetButtonDown ("Fire1") && Dir == Directions.UpLeft) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = -5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = 5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetButtonDown ("Fire1") && Dir == Directions.DownRight) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = 5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = -5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
		else if (Input.GetButtonDown ("Fire1") && Dir == Directions.DownLeft) 
		{
			if (Ammo > 0) 
			{
				Audio.PlayOneShot(Shoot);

				GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO, transform.position, Quaternion.identity);

				bullet01.GetComponent<PlayerBullet> ().xspeed = -5.0f;
				bullet01.GetComponent<PlayerBullet> ().yspeed = -5.0f;

				Ammo= Ammo - 1;
			}
			else 
			{
				Audio.PlayOneShot(NoAmmo);
			}
		}
			
	
	}

	public void AmmoAmount (int Ammopoints)
	{
		Ammo += Ammopoints;
	}

}


public enum Directions
{
	None,
	Up,
	Down,
	Left,
	Right,
	UpRight,
	UpLeft,
	DownLeft,
	DownRight
}

public enum DashState 
{
	Ready,
	Dashing,
	Cooldown
}

