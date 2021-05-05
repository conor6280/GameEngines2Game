using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public float timestamp = 0;
    public float coolDown = 8.0f;

    public GameObject Player;

    const float MAX_MOVE_DISTANCE = 200.0f;
    const float DECELERATION_FACTOR = 0.6f;
    float moveDistance;

    Vector3 source;
    Vector3 target;
    Vector3 outputVelocity;
    Vector3 directionToTarget;
    Vector3 velocityToTarget;

    float distanceToTarget;
    float speed;

    private Rigidbody _rigidbody;

    public void OnEnable()
    {
        timestamp = Time.time + coolDown;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveDistance = MAX_MOVE_DISTANCE * Time.deltaTime;
        source = transform.position;
        if (Player != null && Time.time <= 7.5f)
        {
            target = Player.transform.position;
        }
        
        else
        {
            target = transform.position;
            return;
        }

        outputVelocity = Arrive(source, target);

        _rigidbody.AddForce(outputVelocity, ForceMode.VelocityChange);
    }

    private Vector3 Seek(Vector3 source, Vector3 target, float moveDistance)
    {
        directionToTarget = Vector3.Normalize(target - source);
        velocityToTarget = moveDistance * directionToTarget;
        return velocityToTarget - _rigidbody.velocity;
    }

    private Vector3 Arrive(Vector3 source, Vector3 target)
    {
        distanceToTarget = Vector3.Distance(source, target);
        directionToTarget = Vector3.Normalize(target - source);
        speed = (distanceToTarget / DECELERATION_FACTOR / 5) * 2;
        velocityToTarget = speed * directionToTarget;
        return velocityToTarget - _rigidbody.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Supernova")
        {
            Destroy(gameObject);
        }
    }
}