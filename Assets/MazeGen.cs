using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    hücre[,] hücreler = new hücre[20, 20];

    public GameObject maze;
    public Transform parent;

    public Material renk1, renk2;

    void Start()
    {
        for(int y = 0; y < 20; y++){
            for(int x = 0; x < 20; x++){
               GameObject go = Instantiate(maze, new Vector3(x, 0, y), Quaternion.identity, parent);
                go.name = x + " " + y;
            }
        }

        hücre rndh = hücreler[Random.Range(0, 20), Random.Range(0, 20)];
        string name = Random.Range(0, 20) + " " + Random.Range(0, 20);
        GameObject rgo = GameObject.Find("parent/" + name);

        rgo.GetComponent<Renderer>().material = renk1;
    }
    void Update(){
        
    }

    void harita(){
        hücre rndh = hücreler[Random.Range(0, 20), Random.Range(0, 20)];
        string name = "rndh.x +  + rndh.y";
        GameObject.Find("parent/" + name);
    }
}

public class hücre{
    string name;

    bool dolu = false;
}