using UnityEngine;

namespace Scripts.SpawnObject
{
    public class SpawnRandomObject : AbsSpawn
    {
        [Header("Types of GameObject")]
        [SerializeField] private GameObject[] objectsType;

        [Header("For showing objects")]
        [SerializeField] private Vector2 spawnRangeX;
        [SerializeField] private Vector2 spawnRangeY;

        [Header("GameObject spawn Intervals")]
        [SerializeField] private float interval;
        private void Start()
        {
            spawnInterval = interval;
            StartCoroutine(SpawnObjectCoroutine());
        }

        #region Spawn
        protected override void SpawnRegion()
        {
            int randomIndex = Random.Range(0, objectsType.Length);

            float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
            float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(objectsType[randomIndex], spawnPosition, Quaternion.identity);
        }
        #endregion
    }
}

