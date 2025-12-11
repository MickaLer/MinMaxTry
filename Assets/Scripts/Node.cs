using System.Collections.Generic;

public class Node {
    public int AIPoints;
    public List<Node> ChildNodes = new();
    public bool IsTerminal;
    public Pieces[,] Table;

    public Node(Pieces[,] table) {
        Table = (Pieces[,])table.Clone();
    }

    public List<Node> GetChilds(Factions tourActuel, Node node) {
        int adversaryCount = 0;
        foreach (var variable in node.Table) {
            if (variable == null) {
                continue;
            }

            if (tourActuel != variable.Faction) {
                adversaryCount++;
                continue;
            }

            variable.PossibleMove(this);
        }

        if (adversaryCount == 0) IsTerminal = true;
        return ChildNodes;
    }
}