using UnityEngine;
using System.Collections;

public class Chair : MonoBehaviour {

    public bool IsTarget = false;
    public bool Horizontal = false;
    public float Look;
    

    void Start()
    {
       
    }

    internal bool Direction()
    {
        return Horizontal;
    }

    internal float LookFloat()
    {
        return Look;
    }
}
