using UnityEngine;
using Scripts.GameOneControllers.PlayerLogicOne.PlayerMovement;
using System.Net;

namespace Scripts.GameOneControllers.EnemyLogicOne.EnemyMovement
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private MovementPattern customMovementPattern;
        [SerializeField] private float speedUp;

        [Header("Linear")]
        [SerializeField] private float customSpeed;
        [SerializeField] private Vector2 customPointA;
        [SerializeField] private Vector2 customPointB;

        [Header("Random")]
        private float randomSpeed;
        private Vector2 randomPointA;
        private Vector2 randomPointB;
        private float randomOverrideNumder;

        [Header("Circular")]
        [SerializeField] private bool rotateClockwise = true;
        [SerializeField] private Vector2 customCenterPoint;
        [SerializeField] private float customRadius;
        private Animator meteorAnimator;

        private float time;
        private bool isStopped = false;
        private PlayerMovement playerMovement;

        private void Start()
        {
            meteorAnimator = GetComponentInChildren<Animator>();
            playerMovement = FindObjectOfType<PlayerMovement>();

            float startPointX = Random.Range(-7f, -4f);
            float endPointX = Random.Range(7f, 4f);
            randomPointA = new Vector2(startPointX, 0);
            randomPointB = new Vector2(endPointX, 0);
            randomSpeed = Random.Range(0.5f, 2.5f);
            randomOverrideNumder = Random.Range(0f, 1f);
        }

        private void Update()
        {
            transform.position += Vector3.up * Time.deltaTime * speedUp;

            TapBall();

            PatternMovement();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Zona"))
            {
                isStopped = true;
            }
        }

        #region TouchTap
        private void TapBall()
        {
            try
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (isStopped == true)
                    {
                        Frozen();
                        
                    }
                }
            }
            catch (System.Exception)
            {

            }
        }

        private int counter = 0;
        public void Frozen()
        {
            if (counter == 0)
            {
                counter = 1;

                customSpeed = 0f;
                randomSpeed = 0f;
                AudioManager.Instance.PlaySFX(AudioManager.Instance.BlasterShotOne);
                playerMovement.Freeze();
                meteorAnimator.SetTrigger("IsFrozen");
            }
        }
        #endregion

        #region PatternMovement
        public enum MovementPattern
        {
            Linear,
            RandomLinear,
            Circular
            // Additional patterns can be added here
        }

        private void PatternMovement()
        {
            MovementPattern pattern = customMovementPattern;

            switch (customMovementPattern)
            {
                case MovementPattern.Linear:
                    MoveLinear();
                    break;
                case MovementPattern.RandomLinear:
                    MoveRandomLinear();
                    break;
                case MovementPattern.Circular:
                    MoveCircular();
                    break;
                    // Additional patterns can be added here
            }
        }

        private void MoveLinear()
        {
            time += customSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.Lerp(customPointA, customPointB, Mathf.PingPong(time, 1));
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.y);
        }

        private void MoveRandomLinear() 
        {
            time += randomSpeed * Time.deltaTime;
            if (randomOverrideNumder > 0.5)
            {
                Vector2 newPosition = Vector2.Lerp(randomPointA, randomPointB, Mathf.PingPong(time, 1));
                transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.y);
            }
            else if (randomOverrideNumder <= 0.5)
            {
                Vector2 newPosition = Vector2.Lerp(randomPointB, randomPointA, Mathf.PingPong(time, 1));
                transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.y);
            }
        }
        private void MoveCircular()
        {
            float angleIncrement = customSpeed * (rotateClockwise ? -1 : 1) * Time.deltaTime;
            time += angleIncrement;

            time = (time + 2 * Mathf.PI) % (2 * Mathf.PI);

            Vector2 centerPoint = customCenterPoint;
            float radius = customRadius;

            float newX = centerPoint.x + Mathf.Cos(time) * radius;
            float newY = centerPoint.y + Mathf.Sin(time) * radius;

            transform.position = new Vector3(newX, transform.position.y, newY);
        }
        # endregion
    }
}
