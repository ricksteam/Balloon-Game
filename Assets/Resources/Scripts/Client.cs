using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System.Threading;

public class Client : MonoBehaviour
{

    Thread t;
    static private StreamReader sr;
    static private TcpClient client;
    public static void StartClient()
    {
        client = new TcpClient("localhost", 54321);
        

        sr = new StreamReader(client.GetStream());
        
        while (true)
        {
            string line = sr.ReadLine();
            Debug.Log(line);
        }
    }
    void Start()
    {
        t = new Thread(new ThreadStart(StartClient));
        t.Start();  
    }

    void OnApplicationQuit()
    {
        sr.Close();
        client.Close();
        Debug.Log(t.IsAlive);
        if(t.IsAlive)
        {
            t.Abort();
            Debug.Log("thread terminated");
        }
    }
}