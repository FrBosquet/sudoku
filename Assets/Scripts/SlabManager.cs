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

  int[] IndexToPosition(int index)
  {
    int j = index % 9;
    int i = Mathf.FloorToInt(index / 9);

    return new int[] { i, j };
  }

  int PositionToIndex(int i, int j)
  {
    return i * 9 + j;
  }

  List<int> AvailableInRow(int row)
  {
    List<int> availables = ValidValues();

    for (int j = 0; j < 9; j++)
    {
      availables.Remove(indexes[row, j]);
    }

    return availables;
  }

  List<int> AvailableInColumn(int column)
  {
    List<int> availables = ValidValues();

    for (int i = 0; i < 9; i++)
    {
      availables.Remove(indexes[i, column]);
    }

    return availables;
  }


  List<int> AvailableInBlock(int row, int column)
  {
    List<int> availables = ValidValues();

    int mini = Mathf.FloorToInt(row / 3);
    int minj = Mathf.FloorToInt(column / 3);

    for (int i = mini; i < mini + 3; i++)
    {
      for (int j = minj; j < minj + 3; j++)
      {
        availables.Remove(indexes[i, j]);
      }
    }

    return availables;
  }

  List<int> ValidValues()
  {
    return new List<int>{
        1,2,3,4,5,6,7,8,9
    };
  }
}
