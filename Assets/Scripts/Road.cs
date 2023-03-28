using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject RoadPrefab;
    public float offset = 0.707f;
    public Vector3 LastPos;
    private int RoadCount = 0;

    private void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            CreateNewRoadPart();
        }
    }

    public void CreateNewRoadPart()
    {
        Vector3 SpawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
            SpawnPos = new Vector3(LastPos.x + offset, LastPos.y, LastPos.z + offset);
        else
            SpawnPos = new Vector3(LastPos.x - offset, LastPos.y, LastPos.z + offset);
        GameObject g = Instantiate(RoadPrefab, SpawnPos, Quaternion.Euler(0, 45, 0));
        LastPos = g.transform.position;
        
        RoadCount++;
        int SpawnCrystal = Random.Range(5, 10);
        if (RoadCount % SpawnCrystal == 0)
            g.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager GM = new GameManager();
        if (GM.InputDetected())
        {
            for(int i = 0; i < 20; i++)
            {
                CreateNewRoadPart();
            }
        }
    }
}
