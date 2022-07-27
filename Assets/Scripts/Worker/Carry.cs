using UnityEngine;
using UnityEngine.AI;
using CheckPoints;
using Enums;
using UnityTemplateProjects.Worker;

namespace Worker
{
    public class Carry:WorkerAI
    {

        public Carry(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            name = STATE.CARRY;
        }
        
        protected override void Enter()
        {
            base.Enter();
            
            Debug.Log("CARRY ENTER");
            
            Agent.SetDestination(GameEnvironment.Singleton.Checkpoints[0].transform.position);
        }

        protected override void Update()
        {   
            
            
            if (Agent.remainingDistance < 0.1)
            {   
                nextState = new Put(Worker, Gold, anim, Agent,currentScore);
                stage = EVENT.Exit;
            }
            
        }

        protected override void Exit()
        {
            //Anim reset
            base.Exit();
        }
    }
}