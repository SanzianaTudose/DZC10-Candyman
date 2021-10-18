using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
** Draws FOV Mesh on the XZ axis
*/

public class FieldOfView : MonoBehaviour {
    
    
    private Mesh mesh;
    [SerializeField] private float fov = 90f;
    [SerializeField] private int rayCount = 50;
    [SerializeField] private float viewDistance = 10f;
    private Vector3 origin = Vector3.zero;
    [SerializeField] private float startingAngle = 0f;

    private PlayerController playerController;  
    
    public bool playerInRange = false;

    #region Setters
    public void SetOrigin(Vector3 origin) {
        this.origin = origin;
    }
    public void SetStartingAngle(float startingAngle) {
        this.startingAngle = startingAngle - 180 - 45;
    }
    #endregion

    private void Start() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        playerController = PlayerManager.instance.player.transform.GetComponent<PlayerController>();
        if (playerController == null)
            Debug.LogWarning("FieldOfView: PlayerController component not found on Player object.");
    }

    private void LateUpdate() {
        SpawnMesh();
    }

    private void SpawnMesh() {
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        // Mesh properties
        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[rayCount + 2];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        playerInRange = false;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;

            // Consider obstacles blocking FOV Mesh
            RaycastHit raycastHit;
            bool hit = Physics.Raycast(origin, GetVectorFromAngle(angle), out raycastHit, viewDistance);
            if (!hit)
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            else
                vertex = raycastHit.point;

            if (!playerInRange)
                playerInRange = checkPlayerHit(raycastHit);    

            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;

            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private bool checkPlayerHit(RaycastHit hit) {
        if (hit.transform == null)
            return false;

        if (hit.transform.tag == "Player") {
            return true;
        }

        return false;
            
    }

    #region Helper Methods
    private Vector3 GetVectorFromAngle(float angle) {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
    }
    #endregion
}
