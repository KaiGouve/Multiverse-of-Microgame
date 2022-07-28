using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rename : MonoBehaviour
{
    [SerializeField] string rename;
    
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.name = rename;
    }

}
