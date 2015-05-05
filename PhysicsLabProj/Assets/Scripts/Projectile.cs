using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float power;
	public Vector3 launch_force;
	public bool shot;
    public GameObject Mortar;
    private Vector3 tip;
    public Transform target;
	// Use this for initialization
	void Start () {
        tip = Mortar.transform.position;
        target = GameObject.Find("Target").GetComponent<Transform>();
        shot = false;
	}


    Vector3 BallisticVelocity(Transform target, float angle)
    {
        Vector3 dir = target.position - tip; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }





    // Update is called once per frame
    void FixedUpdate () {
		if (Input.GetKey (KeyCode.Space) && shot == false) {
                //GameObject Projectile = Instantiate(Mortar, tip, Quaternion.identity) as GameObject;
                //Projectile.GetComponent<Rigidbody>().velocity = BallisticVelocity(target, 90-(Mortar.GetComponent<MortarControl>().angle_z));





            launch_force.Set(0.0f,
			                 90-(Mortar.GetComponent<MortarControl>().angle_z),
			                 0.0f);
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;
			this.gameObject.GetComponent<Rigidbody>().AddForce (power*launch_force);
			this.gameObject.GetComponent<Rigidbody>().AddRelativeForce (launch_force*power,ForceMode.Impulse);

			shot = true;
		}
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Target")
        {
            Destroy(collider.gameObject);
            print("Winner");
        }
    }
        
}
