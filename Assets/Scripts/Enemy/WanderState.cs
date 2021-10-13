using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    public GameObject[] waypoints;

    public GameObject lantern;

    private bool chasing;

    public float range;

    void Start()
    {
        FindNextPoint();
        AddTransition<ChaseState>(() => chasing);
    }

    public override void Update()
    {
        if (Vector3.Distance(transform.position, controller.destPos) <= 3.0f)
        {
            FindNextPoint();
        }
    }

    public void FixedUpdate()
    {
        Debug.DrawRay(lantern.transform.position, lantern.transform.forward * range, Color.black);
        if (Physics.Raycast(lantern.transform.position, lantern.transform.forward * range, out RaycastHit hit))
        {
            chasing = hit.collider.CompareTag("Player");
        }
    }

    public override void OnDisable()
    {
        base.OnDisable();
        chasing = false;
    }

    public void FindNextPoint()
    {
        int rndIndex = Random.Range(0, waypoints.Length);
        Vector3 rndPosition = Vector3.zero;
        controller.destPos = waypoints[rndIndex].transform.position + rndPosition;
        controller.agent.SetDestination(controller.destPos);
    }
}
