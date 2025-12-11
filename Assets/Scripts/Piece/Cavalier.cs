using UnityEngine;

public class Cavalier : Pieces {
    public Cavalier(int valeur, Factions factions, string tag, Vector2Int pos) {
        Value = valeur;
        Faction = factions;
        Tag = tag;
        Position = pos;
    }

    public override void PossibleMove(Node node) {
        if (Position.x - 2 >= 0 && Position.y - 1 >= 0 && node.Table[Position.x - 2, Position.y - 1] == null ||
            Position.x - 2 >= 0 && Position.y - 1 >= 0 &&
            node.Table[Position.x - 2, Position.y - 1].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x - 2, Position.y - 1] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x - 2, Position.y - 1));
            node.ChildNodes.Add(states);
        }

        if (Position.x + 2 < 8 && Position.y - 1 >= 0 && node.Table[Position.x + 2, Position.y - 1] == null ||
            Position.x + 2 < 8 && Position.y - 1 >= 0 &&
            node.Table[Position.x + 2, Position.y - 1].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x + 2, Position.y - 1] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x + 2, Position.y - 1));

            node.ChildNodes.Add(states);
        }

        if (Position.x - 1 >= 0 && Position.y - 2 >= 0 && node.Table[Position.x - 1, Position.y - 2] == null ||
            Position.x - 1 >= 0 && Position.y - 2 >= 0 &&
            node.Table[Position.x - 1, Position.y - 2].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x - 1, Position.y - 2] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x - 1, Position.y - 2));
            node.ChildNodes.Add(states);
        }

        if (Position.x + 1 < 8 && Position.y - 2 >= 0 && node.Table[Position.x + 1, Position.y - 2] == null ||
            Position.x + 1 < 8 && Position.y - 2 >= 0 &&
            node.Table[Position.x + 1, Position.y - 2].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x + 1, Position.y - 2] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x + 1, Position.y - 2));
            ;
            node.ChildNodes.Add(states);
        }

        if (Position.x - 2 >= 0 && Position.y + 1 < 8 && node.Table[Position.x - 2, Position.y + 1] == null ||
            Position.x - 2 >= 0 && Position.y + 1 < 8 &&
            node.Table[Position.x - 2, Position.y + 1].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x - 2, Position.y + 1] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x - 2, Position.y + 1));
            ;
            node.ChildNodes.Add(states);
        }

        if (Position.x + 2 < 8 && Position.y + 1 < 8 && node.Table[Position.x + 2, Position.y + 1] == null ||
            Position.x + 2 < 8 && Position.y + 1 < 8 && node.Table[Position.x + 2, Position.y + 1].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x + 2, Position.y + 1] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x + 2, Position.y + 1));
            ;
            node.ChildNodes.Add(states);
        }

        if (Position.x - 1 >= 0 && Position.y + 2 < 8 && node.Table[Position.x - 1, Position.y + 2] == null ||
            Position.x - 1 >= 0 && Position.y + 2 < 8 &&
            node.Table[Position.x - 1, Position.y + 2].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x - 1, Position.y + 2] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x - 1, Position.y + 2));
            ;
            node.ChildNodes.Add(states);
        }

        if (Position.x + 1 < 8 && Position.y + 2 < 8 && node.Table[Position.x + 1, Position.y + 2] == null ||
            Position.x + 1 < 8 && Position.y + 2 < 8 && node.Table[Position.x + 1, Position.y + 2].Faction != Faction) {
            var states = new Node(node.Table);
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x + 1, Position.y + 2] =
                new Cavalier(Value, Faction, Tag, new Vector2Int(Position.x + 1, Position.y + 2));
            ;
            node.ChildNodes.Add(states);
        }
    }
}