using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is meant to test loading user data from disk.
/// Jay Hawkins
/// </summary>
public class LoadUser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        User.LoadUser();   
    }
}
