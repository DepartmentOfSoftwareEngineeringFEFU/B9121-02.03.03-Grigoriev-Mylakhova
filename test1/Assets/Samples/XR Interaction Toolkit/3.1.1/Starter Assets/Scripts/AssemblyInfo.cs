using UnityEngine;

public class AssemblyInfo : MonoBehaviour
{
    [Tooltip("���� �� � ����� ������� ��������� 3-D ����������?")]
    public bool hasAssembly = true;

    
    public GameObject assemblyPrefabOverride;

    [Tooltip("��� �����, � ������� ��������� 3D-���������� ������ ����� �������")]
    public string instructionSceneName;
}
