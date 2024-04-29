using UnityEngine;

namespace Scripts.GameTwo.Enemy
{
    public class LogicMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 speed;

        private void FixedUpdate()
        {
            transform.Translate(speed.x * Time.deltaTime, speed.y * Time.deltaTime, 0);
        }
    }
}
