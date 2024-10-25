using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] User MainUser;
    public static User user;

    void Awake()
    {
        if(user == null)
        {
            user = MainUser;
        }
    }
}
