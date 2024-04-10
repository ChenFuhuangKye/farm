using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

public class CraneTransfer : MonoBehaviour
{
    public ConnectRosBridge connectRos;
    public string craneInputTopic = "/crane";
    public string craneOutputTopic = "/crane_move";


    // Start is called before the first frame update
    void Start()
    {        
        connectRos.ws.OnMessage += OnWebSocketMessage;
        connectRos.SubscribeToTopic(craneInputTopic, "std_msgs/msg/String");        
    }

    private void OnWebSocketMessage(object sender, MessageEventArgs e)
    {
        string jsonString = e.Data;
        var genericMessage = JsonUtility.FromJson<GenericRosMessage>(jsonString);
        if (genericMessage.topic == craneInputTopic)
        {                        
            RobotNewsMessageString message = JsonUtility.FromJson<RobotNewsMessageString>(jsonString);                        
            HandleStringMessage(message);            
        }
    }

    
    private void HandleStringMessage(RobotNewsMessageString message)
    {
        Command jsonData = JsonUtility.FromJson<Command>(message.msg.data);
        float[] movement = new float[3] {jsonData.data.moveX, jsonData.data.moveY, jsonData.data.moveZ};        
        
        connectRos.PublishFloat32MultiArray(craneOutputTopic, movement);        
    }
    public class GenericRosMessage
    {
        public string op;
        public string topic;
    }
    [System.Serializable]
    public class RobotNewsMessageString
    {
        public string op;
        public string topic;
        public StringMessage msg;
    }
    [System.Serializable]
    public class StringMessage
    {
        public string data;
    }
    [System.Serializable]
    public class Command
    {
        public Data data;
    }

    [System.Serializable]
    public class Data
    {
        public float moveX;
        public float moveY;
        public float moveZ;
    }
}
