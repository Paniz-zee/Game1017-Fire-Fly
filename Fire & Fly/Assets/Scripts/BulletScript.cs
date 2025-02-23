using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int direction;
    [SerializeField] float lifetime;
    void Start()
    {
        moveSpeed *= direction;
    }


    void Update()
    {
        transform.Translate(Vector3.right *moveSpeed *Time.deltaTime);
        //Destroy(gameObject, lifetime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
            
        }
    }
}
