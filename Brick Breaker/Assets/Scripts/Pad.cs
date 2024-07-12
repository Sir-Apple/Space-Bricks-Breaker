using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
    }

    Vector3 playerPosition;

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPosition = new Vector3(Mathf.Clamp(x, -4, 3), playerPosition.y, playerPosition.z);
        transform.position = newPosition;
    }
}
