// wrote by ella
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowerFunctions : MonoBehaviour
{
    [SerializeField] public int checkpointNum;
    [SerializeField] public bool levelEnd;
    public static Vector3[] checkpointLocations = new Vector3[3];
    // Start is called before the first frame update
    void Start()
    {
        FlowerFunctions.checkpointLocations[checkpointNum] = transform.position;
    }
}
