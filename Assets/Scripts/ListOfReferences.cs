using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ListOfReferences : MonoBehaviour
{
    public List<AssetReference> shapes;
    
    private bool isReady;
    private int toLoadCount;

    private void Start()
    {
        toLoadCount = shapes.Count;
        foreach (var shape in shapes)
        {
            shape.LoadAssetAsync<GameObject>().Completed += OnLoadedShape;
        }
    }

    private void OnDestroy()
    {
        foreach (var shape in shapes)
        {
            shape.ReleaseAsset();
        }
    }

    private void OnLoadedShape(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            toLoadCount--;

            if (toLoadCount == 0)
            {
                isReady = true;
            }
        }
    }

    public void SpawnThing()
    {
        if (!isReady)
            return;

        var randomIndex = Random.Range(0, shapes.Count);
        var randomCount = Random.Range(1, 5);

        for (int i = 0; i < randomCount; ++i)
        {
            Instantiate(shapes[randomIndex].Asset);
        }
    }
}