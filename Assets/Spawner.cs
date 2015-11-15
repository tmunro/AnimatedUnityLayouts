using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public RectTransform childHolder;
    public RectTransform childPrefab;

    void OnEnable ()
	{
		for(var i = childHolder.childCount - 1; i >= 0; i--)
		{
            Destroy(childHolder.GetChild(i).gameObject);
        }

        var newChildren = Random.Range(2, 6);
		for(var i = 0; i < newChildren; i++)
		{
            var child = GameObject.Instantiate(childPrefab) as RectTransform;
			child.SetParent(childHolder, false);
        }
    }
}
