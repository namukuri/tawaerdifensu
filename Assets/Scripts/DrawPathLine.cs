using UnityEngine;

public class DrawPathLine : MonoBehaviour
{
    [SerializeField]
    private float startLineWidth = 0.5f;

    [SerializeField]
    private float endLineWidth = 0.5f;

    // �o�H�p�̃��C������
    public void CreatePathLine(Vector3[] drawPaths)
    {
        TryGetComponent(out LineRenderer lineRenderer);
        

        // ���C���̑����𒲐�
        lineRenderer.startWidth = startLineWidth;
        lineRenderer.endWidth = endLineWidth;

        // �������郉�C���̒��_����ݒ�(����͎n�_�ƏI�_���P����)
        lineRenderer.positionCount = drawPaths.Length;

        // ���C�����P����
        lineRenderer.SetPositions(drawPaths);
    }
}
