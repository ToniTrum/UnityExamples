using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    [Header("Meshes")]
    [SerializeField] private Mesh trunkMesh;
    [SerializeField] private Mesh crownMesh;

    [Header("Materials")]
    [SerializeField] private Material trunkMaterial;
    [SerializeField] private Material crownMaterial;

    [Header("Spawn settings")]
    [SerializeField] private int treeCount = 1000;
    [SerializeField] private float areaSize = 50f;

    private List<Matrix4x4> trunkMatrices;
    private List<Matrix4x4> crownMatrices;

    void Awake()
    {
        trunkMatrices = new List<Matrix4x4>();
        crownMatrices = new List<Matrix4x4>();

        for (int i = 0; i < treeCount; i++)
        {
            Vector3 pos = new(
                Random.Range(-areaSize, areaSize),
                50f,
                Random.Range(-areaSize, areaSize)
            );

            if (!Physics.Raycast(pos, Vector3.down, out RaycastHit hit, 100f))
                continue;

            float scale = Random.Range(0.8f, 1.2f);

            trunkMatrices.Add(
                Matrix4x4.TRS(
                    hit.point,
                    Quaternion.identity,
                    Vector3.one * scale
                )
            );

            crownMatrices.Add(
                Matrix4x4.TRS(
                    hit.point + Vector3.up * (trunkMesh.bounds.size.y * scale),
                    Quaternion.identity,
                    2f * scale * Vector3.one
                )
            );
        }
    }

    void Update()
    {
        Graphics.DrawMeshInstanced(trunkMesh, 0, trunkMaterial, trunkMatrices);
        Graphics.DrawMeshInstanced(crownMesh, 0, crownMaterial, crownMatrices);
    }
}
