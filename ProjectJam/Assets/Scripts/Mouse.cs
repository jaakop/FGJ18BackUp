using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mouse : MonoBehaviour
{
    public const float Speed = 10;

    private Transform Target;
    private Vector3 Destination;

    private Quaternion Rotation;

    private int Health = 50;

    public void Start()
    {
        Invoke("SetDestination", Random.Range(3, 7));
    }

    private void SetDestination ()
    {
        var Available = new List<Transform>();
        var Pipes = GameObject.FindGameObjectsWithTag("Solid");

        foreach (var Pipe in Pipes)
        {
            if (!Physics.Linecast(transform.position, Pipe.transform.position, LayerMask.NameToLayer("Default")))
            {
                Available.Add(Pipe.transform);
            }
        }

        if (Available.Count > 0)
        {
            Target = Available[Random.Range(0, Available.Count)];
            Destination = Target.position - (Target.position - transform.position).normalized * 2;
        }      
    }

    private void Walk ()
    {
        RaycastHit Hit;

        if (Physics.BoxCast(transform.position, GetComponent<BoxCollider>().size * 0.45f, transform.forward, out Hit, transform.rotation, float.MaxValue, 1) &&
            Hit.distance <= 5.0f)
        {
            Rotation = Quaternion.Euler(0, Random.Range(-30, 30), 0) * Quaternion.LookRotation(Vector3.Reflect(transform.forward, Hit.normal));
        }

        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    private Vector3 GetDirection(Vector3 a, Vector3 b)
    {
        var direction = b - a;
        return direction.magnitude < 1 ? direction : direction.normalized;
    }

    public void FixedUpdate()
    {
        if (Target == null)
        {
            Walk();
        }
        else
        {
            var direction = GetDirection(transform.position, Destination);
            GetComponent<Rigidbody>().velocity = direction * Speed;
            Rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            if (Vector3.Distance(transform.position, Destination) <= 2.0f)
            {
                Target.GetComponent<Pipe>().ApplyDamage(10 * Time.fixedDeltaTime);
            }

            if (Target.GetComponent<Pipe>().isBroken())
            {
                Target = null;
                Invoke("SetDestination", Random.Range(3, 7));
            }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, 10 * Time.fixedDeltaTime);
    }

    public void ApplyDamage(int Damage)
    {
        if ((Health -= Damage) <= 0)
        {
            Destroy(gameObject);
        }
    }
}
