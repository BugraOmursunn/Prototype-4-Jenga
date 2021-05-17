using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject CubePrefab;

    [Range(0, 10)]
    [SerializeField]
    private int _columnValue;
    [SerializeField]
    private Material OddMat, EvenMat;
    private Material CubeMat;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private float spawnRotationY = 0;
    private float spawnPosX = 0, spawnPosY = 1, spawnPosZ = 0;


    void Start()
    {
        CubeMat = OddMat;
        for (int i = 0; i < _columnValue; i++)
        {
            GameObject column = new GameObject();
            column.name = "column" + i;
            column.transform.position = new Vector3(0, spawnPosY, 0);

            for (int j = 0; j < 3; j++)
            {

                spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

                GameObject row = Instantiate(CubePrefab, spawnPosition, CubePrefab.transform.rotation);
                row.transform.GetComponent<Renderer>().material = CubeMat;
                row.name = "row" + j;
                row.transform.parent = column.transform;

                spawnPosX += 2;

                if (CubeMat == OddMat)
                    CubeMat = EvenMat;
                else
                    CubeMat = OddMat;
            }

            spawnPosY += 2;
            spawnPosX = 0;

            CenterOnChildred(column.transform);
            column.transform.Rotate(0, spawnRotationY, 0, Space.Self);
            spawnRotationY += 90;


        }

    }
    private void CenterOnChildred(Transform aParent)
    {
        var childs = aParent.Cast<Transform>().ToList();
        var pos = Vector3.zero;
        foreach (var C in childs)
        {
            pos += C.position;
            C.parent = null;
        }
        pos /= childs.Count;
        aParent.position = pos;
        foreach (var C in childs)
            C.parent = aParent;
    }

}
