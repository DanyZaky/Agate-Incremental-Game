using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MalingController : MonoBehaviour
{
    public GameObject malingObj;
    public Button laporButton;
    public AudioSource MalingSound;
    public Text infoMaling;

    public bool isMalingMuncul = false;

    float malingMunculDuration;
    float malingMunculDurationCounter;

    void Start()
    {
        laporButton.onClick.AddListener(() =>
        {
            isMalingMuncul = false;
        });

        malingMunculDuration = Random.Range(20, 25);

        malingMunculDurationCounter = malingMunculDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMalingMuncul == true)
        {
            malingObj.SetActive(true);
            MalingSound.PlayOneShot(MalingSound.clip);
            double currentGold = GameManager.Instance.TotalGold / 10;

            GameManager.Instance.TotalGold -= currentGold * Time.deltaTime;

            infoMaling.text = $" Awas Uangmu Berkurang Sekitar {currentGold.ToString("0")}!";
        }
        else
        {
            malingMunculDurationCounter -= Time.deltaTime;

            if (malingMunculDurationCounter < 0)
            {
                isMalingMuncul = true;
                malingMunculDurationCounter = malingMunculDuration;
            }

            malingObj.SetActive(false);
        }

    }
}
