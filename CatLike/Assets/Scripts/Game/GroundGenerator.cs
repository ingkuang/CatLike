using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint; //Point from where ground tiles will start
    public Ground groundPrefab;
    public float movingSpeed = 5f;
    public int tilesToPreSpawn = 15;

    List<Ground> spawnedGrounds = new List<Ground>();

    public static GroundGenerator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            Ground spawnedGround = Instantiate(groundPrefab, spawnPosition, Quaternion.identity) as Ground;
            spawnPosition = spawnedGround.endpoint.position+groundPrefab.startpoint.localPosition;
            spawnedGround.transform.SetParent(transform);
            spawnedGrounds.Add(spawnedGround);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-spawnedGrounds[0].transform.forward * Time.deltaTime * movingSpeed , Space.World);
        if (mainCamera.WorldToViewportPoint(spawnedGrounds[0].endpoint.position).x < 0)
        {
            //Move the tile to the front if it's behind the Camera
            Ground groundTmp = spawnedGrounds[0];
            spawnedGrounds.RemoveAt(0);
            groundTmp.transform.position = spawnedGrounds[spawnedGrounds.Count - 1].endpoint.position - groundTmp.startpoint.localPosition;
            spawnedGrounds.Add(groundTmp);
        }
    }
}
