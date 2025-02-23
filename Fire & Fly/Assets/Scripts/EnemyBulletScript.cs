using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
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
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //Destroy(gameObject, lifetime);
        if (transform.position.x > 10f || transform.position.x < -10f ||
        transform.position.y > 6f || transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
