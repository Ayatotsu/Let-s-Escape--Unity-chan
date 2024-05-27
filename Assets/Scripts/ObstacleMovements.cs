using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovements : MonoBehaviour
{
    public float speed;
    public float timeToChangeDirection;
    private Vector3 direction = Vector3.right;

    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToChangeDirection);
            direction = direction == Vector3.right ? Vector3.left : Vector3.right;
        }
    }
}
