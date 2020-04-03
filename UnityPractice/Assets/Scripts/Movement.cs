using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject runner;
    public Transform pivot;
    public float speed = 1;
    public GameObject[] bees; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        runner.transform.RotateAround(pivot.position, Vector3.up, Time.deltaTime * speed);
        for (int i = 0; i < bees.Length; i++)
        {
            bees[i].transform.RotateAround(runner.transform.position, Vector3.up, speed);
            bees[i].transform.RotateAround(runner.transform.position, Vector3.right, speed);
        }
      
    }
}


