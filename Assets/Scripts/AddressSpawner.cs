using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class AddressSpawner : MonoBehaviour
{
    public GameObject textPrefab;
    public GameObject player;
    
    public void CheckEntityAndSpawnAddress() {
        if (gameObject.CompareTag("InstructionMonster")) {
            GameObject text = Instantiate(textPrefab, player.transform);
            text.name = "IAT";
            text.transform.localPosition = new Vector3(0f, 1f, -1f);
            string address = Convert.ToString(UnityEngine.Random.Range(0, 7), 2).PadLeft(4, '0');
            text.GetComponent<TextMeshPro>().SetText(address);
        } else if (gameObject.CompareTag("DataMonster")) {
            GameObject text = Instantiate(textPrefab, gameObject.transform.position, Quaternion.identity);
            text.name = "DAT";
            text.transform.localPosition = new Vector3(0f, 0.5f, -1f);
            string address = Convert.ToString(UnityEngine.Random.Range(8, 15), 2).PadLeft(4, '0');
            text.GetComponent<TextMeshPro>().SetText(address);
        }
    }
}