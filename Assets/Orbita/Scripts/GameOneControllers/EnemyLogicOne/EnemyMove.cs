using UnityEngine;

namespace Scripts.GameTwo.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject player;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");

        }
        private void FixedUpdate()
        {
            if (player != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}