using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceObjMove : MonoBehaviour
{
    public Transform pivot;
    public float speed;
    public GameObject target;
    public float myX;
    public float myY;
    public float myZ;
    public float Xrange;
    public float Yrange;
    public float Zrange;
    public float comparison = 0.01f;
    public Vector3 destination;
    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        myX = target.transform.position.x;
        myY = target.transform.position.y;
        myZ = target.transform.position.z;
        newDestination(myX, myY, myZ);
    }

    void newDestination(float X, float Y, float Z)
    {
        destination.x = Random.Range(myX - Xrange, myX + Xrange);
        destination.y = Random.Range(myY - Yrange, myY + Yrange);
        destination.z = Random.Range(myZ - Zrange, myZ + Zrange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        if (Mathf.Round(elapsedTime) == 2)
        {
            newDestination(myX, myY, myZ);
            elapsedTime = 0;
        }
        target.transform.position = Vector3.MoveTowards(target.transform.position, destination, speed * Time.deltaTime);
    }
}
