using CheckPoints;
using UnityEngine;
using UnityEngine.AI;
using CheckPoints;
using UnityTemplateProjects;

namespace Worker
{
    public class GoNear : WorkerAI
    {
        
        public GoNear(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            
        }
        protected override void Enter()
        {   

            base.Enter();
        }

        protected override void Update()
        {
            Agent.destination = Gold.position;

            if (!Gold.gameObject.activeInHierarchy)
            {
                nextState = new Carry(Worker, Gold, anim, Agent,currentScore);
                stage = EVENT.EXIT;
            }
        }

        protected override void Exit()
        {
            
            base.Exit();
        }
    }
}