using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjetoPared : ObjetoCelda
{
    public Tile[] ObstacleTiles;
    public int MaxHealth = 3;

    private int m_HealthPoint;
    private Tile m_OriginalTile;

    public override void Init(Vector2Int cell)
    {
        base.Init(cell);

        m_HealthPoint = MaxHealth;

        m_OriginalTile = GameManager.Instance.BoardManager.GetCellTile(cell);

        if (ObstacleTiles.Length > 0)
        {
            GameManager.Instance.BoardManager.SetCellTile(cell, ObstacleTiles[0]);
        }
    }

    public override bool PlayerWantsToEnter()
    {
        m_HealthPoint -= 1;

        if (m_HealthPoint > 0)
        {
            ActualizarSprite();
            return false;
        }

        GameManager.Instance.BoardManager.SetCellTile(m_Cell, m_OriginalTile);
        Destroy(gameObject);
        return true;
    }

    private void ActualizarSprite()
    {

        int indiceSprite = MaxHealth - m_HealthPoint;

        if (indiceSprite >= 0 && indiceSprite < ObstacleTiles.Length)
        {
            Tile nuevoTile = ObstacleTiles[indiceSprite];
            GameManager.Instance.BoardManager.SetCellTile(m_Cell, nuevoTile);
        }

    }
}