using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour {
	public float destroy_delay;
	public GameObject explosion;
	public float time_to_die;
	private float count;
	private bool touching;
	private Camera Camera1;
	private Camera Camera2;
	
	void Start()
	{
		Camera1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		Camera2 = this.GetComponentInChildren<Camera>();
		count = 0;
	}
	
	void destroy_count()
	{
		if (count < time_to_die)
		{
			count += 1 * Time.deltaTime;
		}
		else
		{
			GameObject.Find("Mortar").GetComponent<MortarControl>().shot_remains = false;
			Camera1.enabled = true;
			Camera2.enabled = false;
			
			//Creates explosion object with script "Explosion"
			Instantiate(explosion, transform.position, transform.localRotation);
			Destroy(this.gameObject,time_to_die);
		}
	}
	
	void Update()
	{
		if (touching)
		{
			destroy_count();
		}
		if (Input.GetKey(KeyCode.Delete))
		{
			GameObject.Find("Mortar").GetComponent<MortarControl>().shot_remains = false;
			Camera1.enabled = true;
			Camera2.enabled = false;
			
			//Creates explosion object with script "Explosion"
			Instantiate(explosion, transform.position, transform.localRotation);
			Destroy(this.gameObject,time_to_die);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			Camera1.enabled = false;
			Camera2.enabled = true;
			
		}
		if (Input.GetKeyUp(KeyCode.C))
		{
			Camera2.enabled = false;
			Camera1.enabled = true;
			
		}
	}
	
	
	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "Target")
		{
			//Creates explosion object with script "Explosion"
			Instantiate(explosion, transform.position, transform.localRotation);
			Destroy(this.gameObject,time_to_die);
			Destroy(collider.gameObject,destroy_delay); 
			print("Winner");
		}
		else
		{
			touching = true;
		}
	}
	
	
	
}

