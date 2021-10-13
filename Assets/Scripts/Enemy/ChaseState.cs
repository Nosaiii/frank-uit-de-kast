using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    void Start()
    {
        AddTransition<WanderState>(() => controller.distanceToPlayer >= maxDistance);
    }

    public override void Update()
    {
        controller.destPos = controller.player.transform.position;
        controller.agent.SetDestination(controller.destPos);
    }
}
