using UnityEngine;
using RPG.Combat;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;

        private void Start() {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
        }

        private void Update()
        {
            if(InAttackRangeOfPlayer() && CanAttack()) {
                print(gameObject.name + " is in chase radius");
                fighter.Attack(player.gameObject);

            } else {
                fighter.Cancel();
            }
        }

        private bool CanAttack() {
            bool playerIsValid = fighter.CanAttack(player.gameObject);
            bool enemyIsValid = fighter.CanAttack(gameObject);
            return playerIsValid && enemyIsValid;
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return distanceToPlayer <= chaseDistance; 
        }
    }
}