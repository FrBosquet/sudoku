using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabManager : MonoBehaviour
{
  private int[,] indexes = new int[9, 9];
  public GameObject slabPrefab;

  private void Start()
  {
    PopulateIndexes();
    for (int i = 0; i < 9; i++)
    {
      for (int j = 0; j < 9; j++)
      {
        GameObject newSlab = Instantiate(slabPrefab, new Vector3(i - 4, 0, j - 4), slabPrefab.transform.rotation);
        newSlab.transform.SetParent(transform);
        Slab slab = newSlab.GetComponent<Slab>();

        slab.SetNumber(indexes[i, j]);
      }
    }

  }

  void PopulateIndexes()
  {
    for (int i = 0; i < 9; i++)
    {
      for (int j = 0; j < 9; j++)
      {
        indexes[i, j] = j + 1;
      }
    }
  }
}
