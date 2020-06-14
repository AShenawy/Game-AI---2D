using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This class is responsible for the AI idle state
public class StateIdle : State
{
    // setup inherited constructor
    public StateIdle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
            : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;  // set name of this state
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");  // trigger the idle animation
        base.Enter();
    }

    public override void Update()
    {
        // if AI saw the player, then exit idle state and start chasing
        if (CanSeePlayer())
        {
            nextState = new StatePursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        // Set a check to exit the Update stage and go to next one (Exit), otherwise will be stuck in Update forever
        // This condition creates 10% chance to exit Update stage
        else if(Random.Range(0, 100) < 10)
        {
            nextState = new StatePatrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");    // Reset the triggert set to make sure it's clear before leaving state
        base.Exit();
    }

}
