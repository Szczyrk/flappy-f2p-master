using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class FlappyObstaclesSpawner : MonoBehaviour {

	public GameObject obstaclePrefab;
    public float spawnWait;
    public float startWait;
    public float x, y, gapHeight;
    public float gapWidth;
    public FlappyPlayer Flappy;   



    List<GameObject> spawnedObstacles = new List<GameObject>();

   void Start()
    {
       StartCoroutine(waitSpawner());
    }

    void Update()
    {
     
    }
   public void Spawn(float x, float y, float gapHeight)
    {
        
        GameObject spawned = GameObject.Instantiate(obstaclePrefab);
        spawned.transform.parent = transform;
        spawned.transform.position = new Vector3(x+ Random.Range(-gapWidth, gapWidth), Random.Range (-y,y),0);
        spawnedObstacles.Add(spawned);
     
        Transform bottomTransform = spawned.transform.FindChild("Bottom");
        Transform topTransform = spawned.transform.FindChild("Top");
        float bottomY = -Random.Range(gapHeight, gapHeight+3) / 2;
        float topY = +Random.Range(gapHeight, gapHeight + 3) / 2;
        bottomTransform.localPosition = Vector3.up * bottomY ;
        topTransform.localPosition = Vector3.up * topY ;
        Destroy(spawned, 10);
        spawnedObstacles.RemoveAt(0);  
       

    }

    public IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (Flappy.spown)
            {
                x += 10;
                Spawn(x, y, gapHeight);

                yield return new WaitForSeconds(spawnWait);
            }
     
    }
}
