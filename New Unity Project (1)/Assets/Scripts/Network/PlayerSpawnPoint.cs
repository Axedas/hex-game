using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonGame.Scripts
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        private void Awake() => PlayerSpawnScript.AddSpawnPoint(transform);

        private void OnDestroy() => PlayerSpawnScript.RemoveSpawnpoint(transform);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 1f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
        }
    }
}


