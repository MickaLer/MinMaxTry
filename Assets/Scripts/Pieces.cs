using UnityEngine;

public abstract class Pieces {
    public Factions Faction;
    public Vector2Int Position;
    public string Tag;
    public int Value;
    public abstract void PossibleMove(Node node);
}