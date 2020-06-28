using UnityEngine;
using System;
using UnityEngine.UI;
using System.Runtime.ExceptionServices;

public class HackPoint
{
    public int port;
    public string password = "";

    public HackPoint()
    {
        UnityEngine.Random.seed = System.Convert.ToInt32(Time.time);
        port = UnityEngine.Random.Range(1, 2048);
        System.Random random = new System.Random(System.Convert.ToInt32(Time.time) * Guid.NewGuid().GetHashCode());
        for (int i = 0; i < UnityEngine.Random.Range(8,32); i++)
        {
            char symbol = Convert.ToChar(random.Next(33, 126));
            password += symbol;
        }
    }
    public string PasswordBreak(int p)
    {
        string text = "";
        if(p == port)
        {
            text += "\n";
            for( int i = 0; i<password.Length; i++)
            {
                for(int j = 33; j<126; j++)
                {
                    if(password[i] == Convert.ToChar(j))
                    {
                        text += Convert.ToChar(j);
                        break;
                    }
                }
            }
            port  = -1;
            
        }
        else
        {
            text += "\n Port lock";
        }
        return text;
    }
}
