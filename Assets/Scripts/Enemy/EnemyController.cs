using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private float elapsedTime;
    public float distanceToPlayer;
    private GameObject player;
    public NavMeshAgent agent;
    public Vector3 destPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
        elapsedTime += Time.deltaTime;
    }
}
