using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    [SerializeField]
    float maxHealth = 0,currentHealth;


    HealthModel healthModel;

    private void Start()
    {
        healthModel = new HealthModel { CurrentHealth = currentHealth, MaxHealth = maxHealth };
        HealthController.Instance.RegisterHealth(UpdateHealthModel);
        HealthController.Instance.UpdateHealthFirstTime(healthModel);
    }

    void OnDisable()
    {
        HealthController.Instance.UnRegisterHealth(UpdateHealthModel);
    }

    void UpdateHealthModel(HealthModel healthModel)
    {
        this.healthModel = healthModel;
    }
	
    public void GetHit(float amount)
    {
        HealthController.Instance.ChangeHealth(healthModel, amount);
    }

}
