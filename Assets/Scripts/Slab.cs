using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slab : MonoBehaviour
{
  [SerializeField] int number;
  public TextMesh label;

  void Update()
  {
    label.text = number.ToString();
  }

  public void SetNumber(int newNumber)
  {
    number = newNumber;
  }
}
