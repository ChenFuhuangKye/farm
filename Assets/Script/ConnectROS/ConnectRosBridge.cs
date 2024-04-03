using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
public class ConnectRosBridge : MonoBehaviour
{
    public string rosbridgeServerAddress = "localhost:9090";
    public WebSocket ws;

    // Start is called before the first frame update
    void Start()
    {
        string protocol = "ws://";
        ws = new WebSocket(protocol + rosbridgeServerAddress);
        ws.Connect();
    }

    private void OnDestroy()
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Close();
        }
    }
}
