using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour{

	Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	

	void Update () 
	{
		Movement ();
		{
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", move);
		}
	}

	void Movement()

	{
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate(Vector2.right * 3f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate(-Vector2.right * 3f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
	}
}
