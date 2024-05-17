using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.GameTwo.PlayerBall
{
    public class RotationBallMovement : MonoBehaviour
    {
        [Header("Ball References")]
        [SerializeField] private float speed = 1f;
        [SerializeField] private float radius = 2f;
        [SerializeField] private bool rotateClockwise = true;
        [SerializeField] private GameObject player;
        private float rotationSpeed = 0f;

        [SerializeField] private GameObject spriteRendererIno;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Vector2 playerPosition = player.transform.position;
            MoveCircular(playerPosition);

            BallTap();
        }

        private void BallTap()
        {
            try
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.BlasterShotOne);
                    rotateClockwise = !rotateClockwise;
                }
            }
            catch (System.Exception)
            {
                // Handle exception (e.g., no touch input detected)
            }
        }

        private void MoveCircular(Vector2 playerPosition)
        {
            rotationSpeed += speed * (rotateClockwise ? -1 : 1) * Time.deltaTime;

            float newX = playerPosition.x + Mathf.Cos(rotationSpeed) * radius;
            float newY = playerPosition.y + Mathf.Sin(rotationSpeed) * radius;

            transform.position = new Vector3(newX, newY, transform.position.z);
        }
    }
}
