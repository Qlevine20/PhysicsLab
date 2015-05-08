using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public ParticleSystem explosion;
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
            Destroy(this.gameObject);
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
            Destroy(this.gameObject);
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

            Instantiate(explosion, transform.position, transform.localRotation);
            //collider.gameObject.GetComponent<TargetPart>().Explosion.enableEmission = true ;
            //collider.gameObject.GetComponent<TargetPart>().Explosion.Play(true);
            //Destroy(collider.gameObject);
            print("Winner");
        }
        else
        {
            touching = true;
        }
    }
        
}
