using UnityEngine;
using System.Collections.Generic;
public class EnemyStats : MonoBehaviour
{ 
    public Dictionary<string, Dictionary<string, float>> stats =
        new Dictionary<string, Dictionary<string, float>>
        {
            {
                "Bird",
                new Dictionary<string , float>
                {
                    {"health", 10f },
                    {"speed", 3.5f}
                }
            },
            {
                "Worm",
                new Dictionary< string , float>
                {
                    {"health", 20f },
                    {"speed", 1.5f}
                }
            },
            {
                "Bug",
                new Dictionary< string , float>
                {
                    {"health", 5f },
                    {"speed", 4f}
                }
            },
            {
                "Dog",
                new Dictionary< string , float>
                {
                    {"health", 7.5f },
                    {"speed", 1f}
                }
            },
            {
                "Default",
                new Dictionary< string , float>
                {
                    {"health", 5f },
                    {"speed", .2f}
                }
            }
        };

    public float invincibleTime = 1.5f, numOfFlashes = 3f;

    [SerializeField] public Color flashColor;
}
