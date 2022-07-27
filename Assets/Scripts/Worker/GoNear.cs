using Enums;
using UnityEngine;
using UnityEngine.AI;
using UnityTemplateProjects;
using UnityTemplateProjects.Worker;

namespace Worker
{
    public class GoNear : WorkerAI
    {
        
        public GoNear(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            name = STATE.GONEAR;
        }
        protected override void Enter()
        {   
            Debug.Log("GONEAR ENTER");
            base.Enter();
        }

        protected override void Update()
        {
            Agent.destination = Gold.position;

            if (!Gold.gameObject.activeInHierarchy)
            {
                nextState = new Carry(Worker, Gold, anim, Agent,currentScore);
                
                stage = EVENT.Exit;
            }
        }

        protected override void Exit()
        {
            
            base.Exit();
        }
    }
}