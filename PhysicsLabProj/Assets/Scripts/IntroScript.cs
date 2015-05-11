using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

    public GameObject but_text;
    public static bool intro_over;


    void Start()
    {
        intro_over = false;
    }

    public void Click()
    {
       Destroy(but_text);
       Destroy(GameObject.Find("IntroPanel"));
       intro_over = true;
       Destroy(gameObject);
    }

}
