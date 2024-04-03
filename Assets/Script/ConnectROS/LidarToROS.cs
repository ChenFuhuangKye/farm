using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LidarToROS : MonoBehaviour
{
    public ConnectRosBridge connectRos;
    string topicName = "/scan";

    public void PublishLidar(List<float> rangeData, List<float> intensitiesData)
    {
        DateTime now = DateTime.UtcNow;
        long secs = ((DateTimeOffset)now).ToUnixTimeSeconds();
        long nsecs = ((now.Ticks % TimeSpan.TicksPerSecond) * 100L) / TimeSpan.TicksPerMillisecond; // Corrected nanoseconds calculation
        float angleMin = -Mathf.PI;
        float angleMax = Mathf.PI;
        float angleIncrement = 2 * Mathf.PI / rangeData.Count;
        float timeIncrement = 0.00005f;
        float scanTime = 0.1f;
        float rangeMin = 0.15f;
        float rangeMax = 16.0f;
        string ranges = string.Join(", ", rangeData);
        string intensityValues = string.Join(", ", intensitiesData);

        string jsonMessage = $@"{{
            ""op"": ""publish"",
            ""topic"": ""{topicName}"",
            ""msg"": {{
                ""header"": {{
                    ""stamp"": {{
                        ""secs"": {secs},
                        ""nsecs"": {nsecs}
                    }},
                    ""frame_id"": ""laser""
                }},
                ""angle_min"": {angleMin},
                ""angle_max"": {angleMax},
                ""angle_increment"": {angleIncrement},
                ""time_increment"": {timeIncrement},
                ""scan_time"": {scanTime},
                ""range_min"": {rangeMin},
                ""range_max"": {rangeMax},
                ""ranges"": [{ranges}],
                ""intensities"": [{intensityValues}]
            }}
        }}";

        connectRos.ws.Send(jsonMessage);
    }
}
