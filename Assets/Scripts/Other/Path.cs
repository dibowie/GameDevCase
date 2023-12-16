using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform pathParent;

    private void Start()
    {
        Vector3[] pathArray = new Vector3[pathParent.childCount +1];
        for (int i = 0; i < pathArray.Length-1; i++)
        {
            pathArray[i] = pathParent.GetChild(i).position;
        }

        pathArray[pathArray.Length - 1] = pathArray[0];
        transform.DOLocalPath(pathArray, 1,PathType.CatmullRom).SetLoops(-1);
        StartCoroutine(EndPathRoutine());

    }
    IEnumerator EndPathRoutine()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
