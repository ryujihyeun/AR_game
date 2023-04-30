using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScale : MonoBehaviour
{
    Vector3 scale = new Vector3(0.007f, 0.007f, 0.007f);
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = scale;
    }
}
