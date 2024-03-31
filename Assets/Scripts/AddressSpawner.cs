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
            GameObject it = Instantiate(textPrefab, player.transform);
            if (player.transform.localScale.x < 0) {
                Vector3 itScale = it.transform.localScale;
                itScale.x = -Mathf.Abs(itScale.x);
                it.transform.localScale = itScale;
            }
            it.transform.localPosition = new Vector3(0f, 0.3f, -1f);
            it.name = "IT";
            string address = Convert.ToString(UnityEngine.Random.Range(0, 7), 2).PadLeft(4, '0');
            it.GetComponent<TextMeshPro>().SetText("Instruction address: " + address);
        } else if (gameObject.CompareTag("DataMonster")) {
            GameObject dt = Instantiate(textPrefab, player.transform);
            if (player.transform.localScale.x < 0) {
                Vector3 dtScale = dt.transform.localScale;
                dtScale.x = -Mathf.Abs(dtScale.x);
                dt.transform.localScale = dtScale;
            }
            dt.transform.localPosition = new Vector3(0f, 0.2f, -1f);
            dt.name = "DT";
            string address = Convert.ToString(UnityEngine.Random.Range(8, 15), 2).PadLeft(4, '0');
            dt.GetComponent<TextMeshPro>().SetText("Data address: " + address);
        }
    }
}
