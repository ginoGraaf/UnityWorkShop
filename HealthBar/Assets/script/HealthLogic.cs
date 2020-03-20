using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLogic  {

    const int precentage = 1;

	public HealthModel SetNewHealth(HealthModel healthModel,float amount)
    {
        healthModel.CurrentHealth += amount;
        healthModel.HealthPrecentage = (healthModel.CurrentHealth / healthModel.MaxHealth) * precentage;
        return healthModel;
    }
}
