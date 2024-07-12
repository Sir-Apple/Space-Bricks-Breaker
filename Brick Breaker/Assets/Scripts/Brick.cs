using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public GameObject smoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        GameObject flare = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        Destroy(flare, 0.5f);
    }
}
