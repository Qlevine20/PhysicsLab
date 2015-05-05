using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float time_to_die;
    private float count;
    private bool touching;
    void Start()
    {
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
            Destroy(this.gameObject);
        }
    }


    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Target")
        {
            Destroy(collider.gameObject);
            print("Winner");
        }
        else
        {
            touching = true;
        }
    }
        
}
