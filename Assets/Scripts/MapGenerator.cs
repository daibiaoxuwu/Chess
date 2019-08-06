using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace cs
{
    public class MapGenerator : MonoBehaviour
    {
        public GameObject floor01D;
        public GameObject floor02D;
        public GameObject blockS01D;
        public GameObject blockS02D;
        public GameObject blockSpike01D;
        public GameObject blockSpike02D;
        public GameObject Plane;
        public GameObject Pillar01Blue, Pillar01Red;
        public static Vector3 offset = new Vector3(0, 0, 0);
        public static Quaternion rotation = Quaternion.Euler(0, 90, 0);
        
        // Use this for initialization
        void Start()
        {
            Plate.init();
            Plate.floors = new GameObject[15][];
            for (int i = 0; i < 15; i++)
            {
                Plate.floors[i] = new GameObject[15];
            }

            for (int i = -1; i <= 15; ++i)
            {
                for (int j = -1; j <= 15; ++j)
                {
                    GameObject floor;

                    Vector3 position = offset + new Vector3(i * 2, 0f, j * 2);
                    if (i < 5 || i > 9) position += new Vector3(0f, 0.5f, 0);

                    if ((i + j) % 2 == 0)
                        floor = Instantiate(floor01D, position, rotation);
                    else
                        floor = Instantiate(floor02D, position, rotation);
                    floor.transform.parent = gameObject.transform;
                    if (i >= 0 && i < 15 && j >= 0 && j < 15)
                    {
                        floor.GetComponent<BoardSquare>().posx = i;
                        floor.GetComponent<BoardSquare>().posy = j;
                        
                        GameObject newplane = Instantiate(Plane, position + new Vector3(0f, 1.5f, 0f), rotation);
                        newplane.SetActive(false);
                        newplane.transform.parent = floor.transform;
                        Plate.floors[i][j] = floor;
                    }
                    if (i == -1)
                    {
                        GameObject border, border2, border3;
                        if (j == -1)
                        {
                            border = Instantiate(blockSpike02D, position + new Vector3(-0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS02D, position + new Vector3(0.5f, 1.5f, -0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border = Instantiate(blockS01D, position + new Vector3(-0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                        }

                        if (j == 15)
                        {
                            border2 = Instantiate(blockSpike01D, position + new Vector3(-0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS01D, position + new Vector3(0.5f, 1.5f, 0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border2 = Instantiate(blockS02D, position + new Vector3(-0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                        }

                    }

                    if (i == 15)
                    {
                        GameObject border, border2, border3;
                        if (j == -1)
                        {
                            border = Instantiate(blockSpike01D, position + new Vector3(0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS01D, position + new Vector3(-0.5f, 1.5f, -0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border = Instantiate(blockS02D, position + new Vector3(0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                        }

                        if (j == 15)
                        {
                            border2 = Instantiate(blockSpike02D, position + new Vector3(0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS02D, position + new Vector3(-0.5f, 1.5f, 0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border2 = Instantiate(blockS01D, position + new Vector3(0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                        }

                    }
                    if ((j == -1 || j == 15) && i != -1 && i != 15)
                    {
                        float z = 0.5f;
                        if (j == -1) z = -0.5f;
                        GameObject border, border2;
                        border = Instantiate(blockS01D, position + new Vector3(z, 1.5f, z), rotation);
                        border.transform.parent = gameObject.transform;
                        border2 = Instantiate(blockS02D, position + new Vector3(-z, 1.5f, z), rotation);
                        border2.transform.parent = gameObject.transform;
                    }
                }
            }
        }
    }
}