using UnityEngine;

public class ObjetoComida : ObjetoCelda
{
    public int AmountGranted = 10;

    public override void PlayerEntered()
    {
        Destroy(gameObject);

        //increase food
        GameManager.Instance.ChangeFood(AmountGranted);
    }
}
