using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BasicReference2 : MonoBehaviour
{
    public string cubeAddress = "Cube";

    public void SpawnThing()
    {
        Addressables.InstantiateAsync(cubeAddress).Completed += OnCompleteInstantiate;
    }

    private void OnCompleteInstantiate(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject newGo = obj.Result;
            Debug.Log(newGo.name);
        }
        else
        {
            Debug.LogError("실패");
        }
    }
}