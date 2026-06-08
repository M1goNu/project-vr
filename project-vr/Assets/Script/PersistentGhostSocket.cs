using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PersistentGhostSocket : XRSocketInteractor
{
    [Header("Persistent Ghost Settings")]
    [SerializeField] bool m_ShowGhostWhenEmpty = true;

    [SerializeField] Mesh[] m_GhostMeshes;           // ← Array, bisa isi lebih dari 1
    [SerializeField] Material m_GhostMaterial;

    Material m_FallbackMaterial;

    protected override void Awake()
    {
        base.Awake();

        if (m_FallbackMaterial == null)
        {
            m_FallbackMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            m_FallbackMaterial.color = new Color(0f, 0.5f, 1f, 0.4f);
            m_FallbackMaterial.SetFloat("_Surface", 1f);
            m_FallbackMaterial.SetFloat("_Blend", 0f);
            m_FallbackMaterial.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
            m_FallbackMaterial.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
            m_FallbackMaterial.SetInt("_ZWrite", 0);
            m_FallbackMaterial.renderQueue = 3000;
            m_FallbackMaterial.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        }
    }

    void Update()
    {
        if (!m_ShowGhostWhenEmpty) return;
        if (hasSelection) return;
        if (m_GhostMeshes == null || m_GhostMeshes.Length == 0) return;

        var mat = m_GhostMaterial != null ? m_GhostMaterial : m_FallbackMaterial;
        if (mat == null) return;

        var tf = attachTransform != null ? attachTransform : transform;
        var matrix = Matrix4x4.TRS(
            tf.position,
            tf.rotation,
            Vector3.one * interactableHoverScale
        );

        // Loop semua mesh
        foreach (var mesh in m_GhostMeshes)
        {
            if (mesh == null) continue;

            for (int i = 0; i < mesh.subMeshCount; i++)
            {
                Graphics.DrawMesh(
                    mesh,
                    matrix,
                    mat,
                    gameObject.layer,
                    null,
                    i,
                    null,
                    ShadowCastingMode.On,
                    true
                );
            }
        }
    }

    protected override void DrawHoveredInteractables()
    {
        base.DrawHoveredInteractables();
    }
}