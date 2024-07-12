using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force = 100;
    bool isPlaying = false;

    Vector3 firstPosition;
    GameObject parent;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.localPosition;
        parent = transform.parent.gameObject;
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.parent = null;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(force, 0, force);
            isPlaying = true;
        }
    }

    void ResetBall()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        transform.localPosition = firstPosition;
        isPlaying = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    void OnTriggerEnter(Collider other)
    {
        ResetBall();
        gameController.DecreaseLife();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Brick")
        {
            Destroy(other.gameObject);
            gameController.IncreasePoint();
            gameController.UpdateNumberOfBricks();
        }
    }
}
