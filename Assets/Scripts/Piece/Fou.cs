using UnityEngine;

public class Fou : Pieces {
    public Fou(int valeur, Factions factions, string tag, Vector2Int pos) {
        Value = valeur;
        Faction = factions;
        Tag = tag;
        Position = pos;
    }

    public override void PossibleMove(Node node) {
        //Bas Droite
        for (var i = 1; i < 8; i++) {
            if (Position.x + i >= 8 || Position.y + i >= 8) break;
            //Si il n'Position.y a personne sur la position
            if (node.Table[Position.x + i, Position.y + i] == null) {
                var states = new Node(node.Table);
                states.Table[Position.x, Position.y] = null;
                states.Table[Position.x + i, Position.y + i] = new Fou(Value, Faction, Tag,
                    new Vector2Int(Position.x + i, Position.y + i));
                ;
                node.ChildNodes.Add(states);
            }
            //Si il Position.y a un pion sur la positon
            else if (node.Table[Position.x + i, Position.y + i] != null) {
                //Si ce pion n'est pas de la même faction
                if (node.Table[Position.x + i, Position.y + i].Faction != Faction) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x + i, Position.y + i] = new Fou(Value, Faction, Tag,
                        new Vector2Int(Position.x + i, Position.y + i));
                    node.ChildNodes.Add(states);
                }

                break;
            }
        }

        //Haut Droite
        for (var i = 1; i < 8; i++) {
            if (Position.x - i < 0 || Position.y + i >= 8) break;
            //Si il n'Position.y a personne sur la position
            if (node.Table[Position.x - i, Position.y + i] == null) {
                var states = new Node(node.Table);
                states.Table[Position.x, Position.y] = null;
                states.Table[Position.x - i, Position.y + i] = new Fou(Value, Faction, Tag,
                    new Vector2Int(Position.x - i, Position.y + i));
                ;
                node.ChildNodes.Add(states);
            }
            //Si il Position.y a un pion sur la positon
            else if (node.Table[Position.x - i, Position.y + i] != null) {
                //Si ce pion n'est pas de la même faction
                if (node.Table[Position.x - i, Position.y + i].Faction != Faction) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x - i, Position.y + i] = new Fou(Value, Faction, Tag,
                        new Vector2Int(Position.x - i, Position.y + i));
                    ;
                    node.ChildNodes.Add(states);
                }

                break;
            }
        }

        //Haut Gauche
        for (var i = 1; i < 8; i++) {
            if (Position.x - i < 0 || Position.y - i < 0) break;
            //Si il n'Position.y a personne sur la position
            if (node.Table[Position.x - i, Position.y - i] == null) {
                var states = new Node(node.Table);
                states.Table[Position.x, Position.y] = null;
                states.Table[Position.x - i, Position.y - i] = new Fou(Value, Faction, Tag,
                    new Vector2Int(Position.x - i, Position.y - i));
                ;
                node.ChildNodes.Add(states);
            }
            //Si il Position.y a un pion sur la positon
            else if (node.Table[Position.x - i, Position.y - i] != null) {
                //Si ce pion n'est pas de la même faction
                if (node.Table[Position.x - i, Position.y - i].Faction != Faction) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x - i, Position.y - i] = new Fou(Value, Faction, Tag,
                        new Vector2Int(Position.x - i, Position.y - i));
                    ;
                    node.ChildNodes.Add(states);
                }

                break;
            }
        }

        //Bas Gauche
        for (var i = 1; i < 8; i++) {
            if (Position.x + i >= 8 || Position.y - i < 0) break;
            //Si il n'Position.y a personne sur la position
            if (node.Table[Position.x + i, Position.y - i] == null) {
                var states = new Node(node.Table);
                states.Table[Position.x, Position.y] = null;
                states.Table[Position.x + i, Position.y - i] = new Fou(Value, Faction, Tag,
                    new Vector2Int(Position.x + i, Position.y - i));
                ;
                node.ChildNodes.Add(states);
            }
            //Si il Position.y a un pion sur la positon
            else if (node.Table[Position.x + i, Position.y - i] != null) {
                //Si ce pion n'est pas de la même faction
                if (node.Table[Position.x + i, Position.y - i].Faction != Faction) {
                    var states = new Node(node.Table);
                    states.Table[Position.x, Position.y] = null;
                    states.Table[Position.x + i, Position.y - i] = new Fou(Value, Faction, Tag,
                        new Vector2Int(Position.x + i, Position.y - i));
                    ;
                    node.ChildNodes.Add(states);
                }

                break;
            }
        }
    }
}