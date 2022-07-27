using Enums;
using UnityEngine;
using UnityEngine.AI;
using UnityTemplateProjects;
using UnityTemplateProjects.Worker;

namespace Worker
{
    public class Idle : WorkerAI
    {
        public Idle(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            name = STATE.IDLE;
        }
        
        protected override void Enter()
        {   
            Debug.Log("IDLE ENTER!");
            base.Enter();
        }

        protected override void Update()
        {
            
            nextState = new Search(Worker,Gold,anim,Agent,currentScore);
            stage = EVENT.Exit;
            
        }

        protected override void Exit()
        {   
            //anim.isIdle kill
            base.Exit();
        }
    }
}