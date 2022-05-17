using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    public static TileMapManager Instance;
    //public Camera camera;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject MapPrefab;
    private Queue<TileMap> poolingTileMapQueue = new Queue<TileMap>();


    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

  
    void Update()
    {
        
    }


    void MapGenerate()
    {


    }


    private void Initialize(int Count)
    {
        for(int i = 0; i < Count;i++)
        {
            poolingTileMapQueue.Enqueue(CreateTileMap());
        }
    }

    private TileMap CreateTileMap()
    {
        TileMap newMap = Instantiate(MapPrefab, transform).GetComponent<TileMap>();
        newMap.gameObject.SetActive(false);
        return newMap;

    }

    public static TileMap GetTileMap()
    {
        if(Instance.poolingTileMapQueue.Count > 0)
        {
            TileMap tileMap = Instance.poolingTileMapQueue.Dequeue();
            tileMap.transform.SetParent(null);
            tileMap.gameObject.SetActive(true);
            return tileMap;
        }
        else
        {
            TileMap tileMap = Instance.CreateTileMap();
            tileMap.transform.SetParent(null);
            tileMap.gameObject.SetActive(true);
            return tileMap;
        }

    }

    public static void ReturnTileMap(TileMap tileMap)
    {
        tileMap.gameObject.SetActive(false);
        tileMap.transform.SetParent(Instance.transform);
        Instance.poolingTileMapQueue.Enqueue(tileMap);
    }



}
