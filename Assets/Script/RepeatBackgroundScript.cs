using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundScript : MonoBehaviour
{
    public GameObject backgroundImg;
    // Start is called before the first frame update
    void Start()
    {
        GenerateBackground();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateBackground()
    {
        Instantiate(backgroundImg, transform.position, transform.rotation);
    }
}
