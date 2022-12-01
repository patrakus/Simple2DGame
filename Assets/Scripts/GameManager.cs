using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region MEMBERS

    [SerializeField]
    private GameObject enemyPrefab;
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
            Instantiate(enemyPrefab, screenPosition, Quaternion.identity);
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
