using UnityEngine;

public class Roi : Pieces {
    public Roi(int valeur, Factions factions, string tag, Vector2Int pos) {
        Value = valeur;
        Faction = factions;
        Tag = tag;
        Position = pos;
    }

    public override void PossibleMove(Node node) {
        //Haut Gauche
        if (Position.x - 1 >= 0 && Position.y - 1 >= 0 && node.Table[Position.x - 1, Position.y - 1] == null ||
            Position.x - 1 >= 0 && Position.y - 1 >= 0 &&
            node.Table[Position.x - 1, Position.y - 1].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x - 1, Position.y - 1] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x - 1, Position.y - 1));
            node.ChildNodes.Add(states);
        }

        //Haut Droite
        if (Position.x + 1 < 8 && Position.y - 1 >= 0 && node.Table[Position.x + 1, Position.y - 1] == null ||
            Position.x + 1 < 8 && Position.y - 1 >= 0 &&
            node.Table[Position.x + 1, Position.y - 1].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x + 1, Position.y - 1] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x + 1, Position.y - 1));
            node.ChildNodes.Add(states);
        }

        //Bas Gauche
        if (Position.x - 1 >= 0 && Position.y + 1 < 8 && node.Table[Position.x - 1, Position.y + 1] == null ||
            Position.x - 1 >= 0 && Position.y + 1 < 8 &&
            node.Table[Position.x - 1, Position.y + 1].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x - 1, Position.y + 1] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x - 1, Position.y + 1));
            node.ChildNodes.Add(states);
        }

        //Bas Droite
        if (Position.x + 1 < 8 && Position.y + 1 < 8 && node.Table[Position.x + 1, Position.y + 1] == null ||
            Position.x + 1 < 8 && Position.y + 1 < 8 && node.Table[Position.x + 1, Position.y + 1].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x + 1, Position.y + 1] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x + 1, Position.y + 1));
            node.ChildNodes.Add(states);
        }

        //Haut
        if (Position.y - 1 >= 0 && node.Table[Position.x, Position.y - 1] == null ||
            Position.y - 1 >= 0 && node.Table[Position.x, Position.y - 1].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x, Position.y - 1] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x, Position.y - 1));
            node.ChildNodes.Add(states);
        }

        //Bas
        if (Position.y + 1 < 8 && node.Table[Position.x, Position.y + 1] == null ||
            Position.y + 1 < 8 && node.Table[Position.x, Position.y + 1].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x, Position.y + 1] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x, Position.y + 1));
            node.ChildNodes.Add(states);
        }

        //Droite
        if (Position.x + 1 < 8 && node.Table[Position.x + 1, Position.y] == null ||
            Position.x + 1 < 8 && node.Table[Position.x + 1, Position.y].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x + 1, Position.y] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x + 1, Position.y));
            node.ChildNodes.Add(states);
        }

        //Gauche
        if (Position.x - 1 >= 0 && node.Table[Position.x - 1, Position.y] == null ||
            Position.x - 1 >= 0 && node.Table[Position.x - 1, Position.y].Faction != Faction) {
            var states = new Node(node.Table);
            ;
            states.Table[Position.x, Position.y] = null;
            states.Table[Position.x - 1, Position.y] =
                new Roi(Value, Faction, Tag, new Vector2Int(Position.x - 1, Position.y));
            node.ChildNodes.Add(states);
        }
    }
}