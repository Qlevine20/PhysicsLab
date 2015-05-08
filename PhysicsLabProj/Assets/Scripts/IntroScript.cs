using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

    public GameObject but_text;
    public static int but_count;
    public static bool intro_over;


    void Start()
    {
        but_count = 4;
        intro_over = false;
    }

    public void Click()
    {
        Destroy(but_text);
        if (but_count == 1)
        {
            Destroy(GameObject.Find("IntroPanel"));
            intro_over = true;
            Destroy(gameObject);
        }
        but_count -= 1;
        Destroy(gameObject);
    }

}
