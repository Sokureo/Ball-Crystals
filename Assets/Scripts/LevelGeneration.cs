using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject CrystalPrefab;
    public int platformCountForward;
    public int platformCountRight;
    public float DistanceBetweenPlatforms;
    public int prefabIndex = 0;
    private int count = 0;
    private float lastZposition = 0f;

    private void Awake()
    {
        Generate();

    }

    private void Update()
    {
        if (lastZposition - 20 < Camera.main.transform.position.z)
        {
            Generate();
        }
    }

    private void Generate()
    {
        count++;
        for (int i = 0; i < platformCountForward; i++)
        {
            if (i != 0)
            {
                prefabIndex = Random.Range(0, PlatformPrefabs.Length);
            }
            GameObject platform = Instantiate(PlatformPrefabs[prefabIndex], transform);
            platform.transform.localPosition = new Vector3(0, 0, DistanceBetweenPlatforms * i + lastZposition);

            int chance = Random.Range(0, 2);
            if (chance == 1)
            {
                GameObject crystal = Instantiate(CrystalPrefab, transform);
                crystal.transform.localPosition = new Vector3(0, 2, DistanceBetweenPlatforms * i + lastZposition);
            }

            for (int j = 1; j < platformCountRight; j++)
            {
                int prefabIndexj = Random.Range(0, PlatformPrefabs.Length);
                GameObject platformj = Instantiate(PlatformPrefabs[prefabIndexj], transform);
                platformj.transform.localPosition = new Vector3(DistanceBetweenPlatforms * j, 0, DistanceBetweenPlatforms * i + lastZposition);
                int chancej = Random.Range(0, 2);
                if (chancej == 1)
                {
                    GameObject crystal = Instantiate(CrystalPrefab, transform);
                    crystal.transform.localPosition = new Vector3(DistanceBetweenPlatforms * j, 2, DistanceBetweenPlatforms * i + lastZposition);
                }
            }

            for (int j = 1; j < platformCountRight; j++)
            {
                int prefabIndexj = Random.Range(0, PlatformPrefabs.Length);
                GameObject platformj = Instantiate(PlatformPrefabs[prefabIndexj], transform);
                platformj.transform.localPosition = new Vector3(-DistanceBetweenPlatforms * j, 0, DistanceBetweenPlatforms * i + lastZposition);
                int chancej = Random.Range(0, 2);
                if (chancej == 1)
                {
                    GameObject crystal = Instantiate(CrystalPrefab, transform);
                    crystal.transform.localPosition = new Vector3(-DistanceBetweenPlatforms * j, 2, DistanceBetweenPlatforms * i + lastZposition);
                }
            }
        }
        lastZposition = DistanceBetweenPlatforms * platformCountForward * count;
    }
}
