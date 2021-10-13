using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    // Start is called before the first frame update
    void Start()
    {
        AddTransition<WanderState>(() => controller.distanceToPlayer >= maxDistance);
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    // Update is called once per frame
    public override void Update()
    {
        controller.destPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        controller.agent.SetDestination(controller.destPos);
    }
}
