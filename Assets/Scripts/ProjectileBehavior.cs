
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
   public float speed = 4.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
