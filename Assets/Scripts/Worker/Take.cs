using UnityEngine;
using UnityEngine.AI;

namespace Worker
{
    public class Take: WorkerAI
    {

        public Take(GameObject _worker, Transform _gold, Animator _anim, NavMeshAgent _agent,int _currentScore) : base(_worker, _gold, _anim, _agent,_currentScore)
        {
            
        }
        
        protected override void Enter()
        {
            base.Enter();
        }

        protected override void Update()
        {
            //
            //stage = EVENT.EXIT;
            
        }

        protected override void Exit()
        {
            //Anim reset
            base.Exit();
        }
    }
}