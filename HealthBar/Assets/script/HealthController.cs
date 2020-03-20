using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    //singleton
    public static HealthController Instance { get; set; }
    HealthLogic healthLogic;
    Action<HealthModel> UpdateHealth;

	// Use this for initialization
	void Awake () {
        Instance = this;
        healthLogic = new HealthLogic();
	}

    public void ChangeHealth(HealthModel healthModel,float amount)
    {
        healthLogic.SetNewHealth(healthModel, amount);
        if(UpdateHealth!=null)
        {
            UpdateHealth(healthModel);
        }
    }

    public void UpdateHealthFirstTime(HealthModel healthModel)
    {
        if (UpdateHealth != null)
        {
            UpdateHealth(healthModel);
        }
    }

    public void RegisterHealth(Action<HealthModel> cbHealth)
    {
        UpdateHealth += cbHealth;
    }
    public void UnRegisterHealth(Action<HealthModel> cbHealth)
    {
        UpdateHealth -= cbHealth;
    }

}
