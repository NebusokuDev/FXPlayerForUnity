using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var dir = new Vector3(horizontal, vertical);

        if (dir.sqrMagnitude >= 1f)
        {
            dir.Normalize();
        }

        Debug.Log(dir.ToString());
    }
}