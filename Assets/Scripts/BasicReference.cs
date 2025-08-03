using UnityEngine;
using UnityEngine.AddressableAssets;

public class BasicReference : MonoBehaviour
{
    public AssetReference baseCube;

    public void SpawnThing()
    {
        baseCube.InstantiateAsync();
    }
}