using UnityEngine;
using UnityEngine.AI;
using Worker;
using Idle = Worker.Idle;

namespace AIInitialize
{
    public class AIInıt : MonoBehaviour
    {
        NavMeshAgent _agent;
        Animator anim;
        public Transform gold;
        WorkerAI _currentState;
        
        public int currentScore;
        
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            
            anim = GetComponent<Animator>();
            
            _currentState = new Idle(gameObject, gold, anim, _agent,currentScore);
        
        }
        
        private void Update()
        {
            _currentState = _currentState.Process();
            
            Debug.Log(_currentState);

        }
    }
}
