using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float distanceToPlayer;
    public GameObject player;
    public NavMeshAgent agent;
    public Vector3 destPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
    }
}
