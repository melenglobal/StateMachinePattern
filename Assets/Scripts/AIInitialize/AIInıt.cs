using UnityEngine;
using UnityEngine.AI;
using Worker;
using Idle = Worker.Idle;

namespace AIInitialize
{
    public class AIInıt : MonoBehaviour
    {
        NavMeshAgent Agent;
        Animator anim;
        public Transform Gold;
        WorkerAI currentState;
        
        public int currentScore;

        // Start is called before the first frame update
        void Start()
        {
            Agent = this.GetComponent<NavMeshAgent>();
            anim = this.GetComponent<Animator>();
            currentState = new Idle(gameObject, Gold, anim, Agent,currentScore);
        
        }

        // Update is called once per frame
        void Update()
        {
            currentState = currentState.Process();

        }
    }
}
