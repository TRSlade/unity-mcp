using UnityEngine;

public class GodController : MonoBehaviour
{
    public GameObject zeusPrefab;
    public GameObject poseidonPrefab;
    public GameObject hadesPrefab;
    public Transform target; // The player to attack

    void Start()
    {
        // Create Zeus
        GameObject zeus = Instantiate(zeusPrefab, new Vector3(-5, 5, 0), Quaternion.identity);
        zeus.GetComponent<ZeusController>().target = target;

        // Create Poseidon
        GameObject poseidon = Instantiate(poseidonPrefab, new Vector3(5, 5, 0), Quaternion.identity);
        // Add Poseidon's attack behavior here

        // Create Hades
        GameObject hades = Instantiate(hadesPrefab, new Vector3(0, 5, 0), Quaternion.identity);
        // Add Hades' attack behavior here
    }
} 