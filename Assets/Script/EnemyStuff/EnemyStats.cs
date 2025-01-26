using UnityEngine;
using System.Collections.Generic;
public class EnemyStats : MonoBehaviour
{ 
    public Dictionary<string, Dictionary<string, float>> stats =
        new Dictionary<string, Dictionary<string, float>>
        {
            {
                "chaser",
                new Dictionary<string , float>
                {
                    {"health", 10f },
                    {"speed", 3.5f}
                }
            },
            {
                "shooting",
                new Dictionary< string , float>
                {
                    {"health", 5f },
                    {"speed", 2f}
                }
            }
        };

    public float invincibleTime = 1.5f, numOfFlashes = 3f;

    [SerializeField] public Color flashColor;
}
