using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseFix : MonoBehaviour
{
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
