using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public Func<bool> condition;
    public State target;
}
