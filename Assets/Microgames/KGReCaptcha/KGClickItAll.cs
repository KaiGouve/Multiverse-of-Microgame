using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGClickItAll : MonoBehaviour
{
  public int cars = 4;
  public GameObject complete;

  public void click()
  {
      cars--;
      if (cars == 0) 
      {
          complete.SetActive(true);
      }
  }
}