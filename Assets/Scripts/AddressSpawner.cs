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
            GameObject iat = Instantiate(textPrefab, player.transform);
            iat.name = "IAT";
            iat.transform.localPosition = new Vector3(0f, 0.3f, -1f);
            string address = Convert.ToString(UnityEngine.Random.Range(0, 7), 2).PadLeft(4, '0');
            iat.GetComponent<TextMeshPro>().SetText(address);
        } else if (gameObject.CompareTag("DataMonster")) {
            GameObject dat = Instantiate(textPrefab, player.transform);
            dat.name = "DAT";
            dat.transform.localPosition = new Vector3(0f, 0.2f, -1f);
            string address = Convert.ToString(UnityEngine.Random.Range(8, 15), 2).PadLeft(4, '0');
            dat.GetComponent<TextMeshPro>().SetText(address);
        }
    }
}
