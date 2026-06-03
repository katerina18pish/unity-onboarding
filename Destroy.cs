using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // команда удалить объект в котором находится скрипт сразу после запуска игры
        Destroy(gameObject);
        print("successful");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
