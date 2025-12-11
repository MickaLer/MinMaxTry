using UnityEngine;

public class Pion : Pieces {
    private Vector2Int _originalPosition;

    public bool HasMoved;

    public Pion(int valeur, Factions factions, string tag, Vector2Int pos, Vector2Int originalPosition) {
        Value = valeur;
        Faction = factions;
        Tag = tag;
        Position = pos;
        _originalPosition = originalPosition;
    }

    public override void PossibleMove(Node node) {
        if (Position.x != _originalPosition.x || Position.y != _originalPosition.y) HasMoved = true;
        switch (Faction) {
            case Factions.Blanc: {
                //Si il n'y a personne devant
                if (Position.x - 1 >= 0 && node.Table[Position.x - 1, Position.y] == null) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x - 1, Position.y] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x - 1, Position.y), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                //Si il n'y a personne à 2 cases devant et que le pion n'as pas encore bouger
                if (Position.x - 2 >= 0 && !HasMoved && node.Table[Position.x - 2, Position.y] == null &&
                    node.Table[Position.x - 1, Position.y] == null) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x - 2, Position.y] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x - 2, Position.y), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                //Si il y a un pion noir à la diagonal gauche
                if (Position.x - 1 >= 0 && Position.y - 1 >= 0 && node.Table[Position.x - 1, Position.y - 1] != null &&
                    node.Table[Position.x - 1, Position.y - 1].Faction == Factions.Noir) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x - 1, Position.y - 1] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x - 1, Position.y - 1), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                //Si il y a un pion noir à la diagonal droite
                if (Position.x - 1 >= 0 && Position.y + 1 < 8 && node.Table[Position.x - 1, Position.y + 1] != null &&
                    node.Table[Position.x - 1, Position.y + 1].Faction == Factions.Noir) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x - 1, Position.y + 1] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x - 1, Position.y + 1), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                break;
            }
            case Factions.Noir: {
                //Si il n'y a personne devant
                if (Position.x + 1 < 8 && node.Table[Position.x + 1, Position.y] == null) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x + 1, Position.y] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x + 1, Position.y), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                //Si il n'y a personne à 2 cases devant et que le pion n'as pas encore bouger
                if (Position.x + 2 < 8 && !HasMoved && node.Table[Position.x + 2, Position.y] == null &&
                    node.Table[Position.x + 1, Position.y] == null) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x + 2, Position.y] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x + 2, Position.y), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                //Si il y a un pion blanc à la diagonal gauche
                if (Position.x + 1 < 8 && Position.y + 1 < 8 && node.Table[Position.x + 1, Position.y + 1] != null &&
                    node.Table[Position.x + 1, Position.y + 1].Faction == Factions.Blanc) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x + 1, Position.y + 1] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x + 1, Position.y + 1), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                //Si il y a un pion blanc à la diagonal droite
                if (Position.x + 1 < 8 && Position.y - 1 >= 0 && node.Table[Position.x + 1, Position.y - 1] != null &&
                    node.Table[Position.x + 1, Position.y - 1].Faction == Factions.Blanc) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x + 1, Position.y - 1] = new Pion(Value, Faction, Tag,
                        new Vector2Int(Position.x + 1, Position.y - 1), _originalPosition);
                    node.ChildNodes.Add(states);
                }

                break;
            }
        }
    }
}