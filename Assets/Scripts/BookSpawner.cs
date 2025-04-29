using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    public GameObject bookPrefab;
    public Transform[] spawnPoints;

    private void OnEnable()
    {
        PlayerUpgrades.OnBookUpgrade += SpawnBook;
    }

    private void OnDisable()
    {
        PlayerUpgrades.OnBookUpgrade -= SpawnBook;
    }

    private void Start()
    {
        for (int i = 0; i < PlayerUpgrades.Instance.bookLevel; i++)
        {
            SpawnBook();
        }
    }

    private int currentBookCount = 0;

    private void SpawnBook()
    {
        if (currentBookCount >= spawnPoints.Length)
            return;

        Instantiate(bookPrefab, spawnPoints[currentBookCount].position, Quaternion.identity);
        currentBookCount++;
    }
}