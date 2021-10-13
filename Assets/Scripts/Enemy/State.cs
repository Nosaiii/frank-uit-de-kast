using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State : MonoBehaviour
{
    public List<Transition> transitions;

    public EnemyController controller;

    public float maxDistance;


    public float curRotSpeed;

    public float curSpeed;

    public virtual void Awake()
    {
        transitions = new List<Transition>();
        // TO-DO
        // setup your transitions here
    }

    public virtual void OnEnable()
    {
        // TO-DO
        // develop state's initialization here
    }

    public virtual void OnDisable()
    {
        // TO-DO
        // develop state's finalization here
    }

    public virtual void Update()
    {
        // TO-DO
        // develop behaviour here
    }

    public void LateUpdate()
    {
        foreach (Transition t in transitions)
        {
            if (t.condition())
            {
                t.target.enabled = true;
                this.enabled = false;
                return;
            }
        }
    }

    public void AddTransition<StateType>(Func<bool> condition) where StateType : State
    {
        Transition newTransition = new Transition
        {
            target = gameObject.GetComponent<StateType>(),
            condition = condition
        };

        transitions.Add(newTransition);
    }

}
