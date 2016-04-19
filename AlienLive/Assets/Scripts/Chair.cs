using UnityEngine;
using System.Collections;

public class Chair : MonoBehaviour {

    public bool IsTarget = false;
    private bool lookDown;
    

    void Start()
    {
        if (transform.position.y== -3.84f || transform.position.y == -5.44f)
        {
            lookDown = true;
        }
        else
        {
            lookDown = false;
        }
    }

    internal bool Look()
    {
        return lookDown;
    }

}
