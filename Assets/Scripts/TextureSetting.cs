using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TextureSetting : MonoBehaviour
{
    public Terrain terrain;
    [SerializeField] [Range(0, 1)] public float low ;
    [SerializeField] [Range(0, 1)] public float mid;
    [SerializeField] [Range(0, 1)] public float high;
    Texture2D texture;
    TerrainLayer[] layers;

    private void Awake()
    {
        terrain = GetComponent<Terrain>();
        

    }

    void Start()
    {
        terrain = GetComponent<Terrain>();
        layers=terrain.terrainData.terrainLayers;
       
        float[,,] map = new float[terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight, 4];
        float[,] heights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.alphamapWidth , terrain.terrainData.alphamapHeight);
        
    


        for (int y = 0; y < terrain.terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrain.terrainData.alphamapWidth; x++)
            {
                

            
                if (heights[x, y] > high)
                {
                    map[x, y, 2] = 1;
                   
                  
                    
                }
                else if (heights[x, y] < mid && heights[y, x] > 0.4f)
                {

                    map[x, y, 0] =1;
                    
                }
                else if (heights[x, y] <= low && heights[y, x] > 0.2f)
                {
                    map[x, y, 3] = 1;
                }
                else
                {
                    map[x, y, 1] = 1;
                }



            }
        }
        terrain.terrainData.SetAlphamaps(0, 0, map);
    }
  
}
