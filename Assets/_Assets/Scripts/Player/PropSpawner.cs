using UnityEngine;
using Unity.Netcode;

public class PropSpawner : NetworkBehaviour
{
    [SerializeField] private Transform _spawnedPropPrefab;
    private Transform _spawnedProp;

    private void Update()
    {
        if(!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            if(_spawnedProp != null) return;

            _spawnedProp = Instantiate(_spawnedPropPrefab, new Vector3(Random.Range(-1f, 5f), 0.5f, 0), Quaternion.identity);
            _spawnedProp.GetComponent<NetworkObject>().Spawn(true);
        }

        if ((Input.GetKeyDown(KeyCode.Y))&&(_spawnedProp != null))
        {
            Destroy(_spawnedProp.gameObject);
            _spawnedProp = null;
        }
    }
}
