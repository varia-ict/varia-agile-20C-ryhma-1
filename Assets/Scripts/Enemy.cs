using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    private Rigidbody enemyRb;
    public Transform player;
    private float dist;
    public float moveSpeed;
    public float howclose;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        if (dist <= 1.5f)
        {
            // Do damage when close to player
        }

    }
}