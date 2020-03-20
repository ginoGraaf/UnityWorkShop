using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour {
    [SerializeField]
    Image HealthBar;

	// Use this for initialization
	void Start () {
        HealthController.Instance.RegisterHealth(UpdateHealthBar);
	}

    void OnDisable()
    {
        HealthController.Instance.UnRegisterHealth(UpdateHealthBar); 
    }

    void UpdateHealthBar(HealthModel healthModel)
    {
        HealthBar.fillAmount = healthModel.HealthPrecentage;
    }

}
