using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Connection connection;
    // Start is called before the first frame update
    void Start()
    {
        connection = (Connection)FindObjectOfType(typeof(Connection));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
