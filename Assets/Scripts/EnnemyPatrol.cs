
using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoint;

    public Transform target;
    private int destPoint = 0;

    public ProjectileBehavior projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si l'ennemi est quasiment arriver a ça destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoint.Length;
            target = waypoint[destPoint];
            transform.Rotate(0, 180, 0);

            Instantiate(projectilePrefab, target.position, transform.rotation);

        }

        

    }
}
