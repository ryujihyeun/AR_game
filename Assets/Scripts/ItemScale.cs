using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0.05f, 0.5f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(0.05f, 0.5f, 0.2f);
    }
}
