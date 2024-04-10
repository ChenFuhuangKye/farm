using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.UrdfImporter.Control;
using UnityEngine;
using WebSocketSharp;

public class CraneRosSubscriber : MonoBehaviour
{
    public ConnectRosBridge connectRos;
    public string topicName = "/crane_move"; 
    public MoveCraneX craneX;
    public MoveCraneY craneY;
    public MoveCraneZ craneZ;
    
    // Start is called before the first frame update
    void Start()
    {
        connectRos.ws.OnMessage += OnWebSocketMessage;
        connectRos.SubscribeToTopic(topicName, "std_msgs/Float32MultiArray");
        
    }

    private void OnWebSocketMessage(object sender, MessageEventArgs e)
    {
        string jsonString = e.Data;        

        if (jsonString.Contains("\"topic\": \""+topicName+"\""))
        {                        
            RobotNewsMessage message = JsonUtility.FromJson<RobotNewsMessage>(jsonString);
            craneX.moveX = message.msg.data[0];
            craneY.moveY = message.msg.data[1];
            craneZ.moveZ = message.msg.data[2];            
        }
    }

    [System.Serializable]
    private class RobotNewsMessage
    {
        public string op;
        public string topic;
        public MessageData msg;
    }

    [System.Serializable]
    public class MessageData
    {
        public LayoutData layout;
        public float[] data;
    }
    [System.Serializable]
    public class LayoutData
    {
        public int[] dim;
        public int data_offset;
    }
}
