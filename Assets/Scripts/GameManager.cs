using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region MEMBERS

    [SerializeField]
    private NPCController enemyPrefab;
    [SerializeField]
    private PlayerController playerTransform;
    [SerializeField]
    [Min(1)]
    private int enemiesCount = 1000;
    private Camera mainCamera;

    #endregion

    #region FUNCTIONS

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError($"Missing enemy prefab in {nameof(GameManager)}!");
            return;
        }

        for (int i = 0; i < enemiesCount; i++)
        {
            Vector3 screenPosition = mainCamera.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), 0));
            screenPosition.z = 0;
            NPCController enemy = Instantiate(enemyPrefab, screenPosition, Quaternion.identity);
            enemy.PlayerTransform = playerTransform.transform;
            enemy.MainCamera = mainCamera;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    #endregion
}
