using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRCheckActive : MonoBehaviour
{
  public int openBoxes = 4;
  public GameObject virusFree;

  public void close()
  {
      openBoxes--;
      if (openBoxes == 0) 
      {
          virusFree.SetActive(true);
      }
  }
}
