// Programmed By Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool moving = true;
    
    // Update is called once per frame
    void Update()
    {
        // YouTube Tutorial Link: https://www.youtube.com/watch?v=K3Ap2_beGnE
        if (moving)
        {
            transform.Rotate(0, 0, 10 * Time.deltaTime, Space.Self);
        }
    }
}
