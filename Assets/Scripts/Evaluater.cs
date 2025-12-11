using UnityEngine;

public class Evaluater : MonoBehaviour {
    private int[,] _pionBlanc = new int[,] {
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 50, 50, 50, 50, 50, 50, 50, 50 },
        { 10, 10, 20, 30, 30, 20, 10, 10 },
        { 5, 5, 10, 25, 25, 10, 5, 5 },
        { 0, 0, 0, 20, 20, 0, 0, 0 },
        { 5, -5, -10, 0, 0, -10, -5, 5 },
        { 5, 10, 10, -20, -20, 10, 10, 5 },
        { 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] _pionNoir = new int[,] {
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 5, 10, 10, -20, -20, 10, 10, 5 },
        { 5, -5, -10, 0, 0, -10, -5, 5 },
        { 0, 0, 0, 20, 20, 0, 0, 0 },
        { 5, 5, 10, 25, 25, 10, 5, 5 },
        { 10, 10, 20, 30, 30, 20, 10, 10 },
        { 50, 50, 50, 50, 50, 50, 50, 50 },
        { 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] _cavalierBlanc = new int[,] {
        { -50, -40, -30, -30, -30, -30, -40, -50 },
        { -40, -20, 0, 0, 0, 0, -20, -40 },
        { -30, 0, 10, 15, 15, 10, 0, -30 },
        { -30, 5, 15, 20, 20, 15, 5, -30 },
        { -30, 0, 15, 20, 20, 15, 0, -30 },
        { -30, 5, 10, 15, 15, 10, 5, -30 },
        { -40, -20, 0, 5, 5, 0, -20, -40 },
        { -50, -40, -30, -30, -30, -30, -40, -50 }
    };

    private int[,] _cavalierNoir = new int[,] {
        { -50, -40, -30, -30, -30, -30, -40, -50 },
        { -40, -20, 0, 5, 5, 0, -20, -40 },
        { -30, 5, 10, 15, 15, 10, 5, -30 },
        { -30, 0, 15, 20, 20, 15, 0, -30 },
        { -30, 5, 15, 20, 20, 15, 5, -30 },
        { -30, 0, 10, 15, 15, 10, 0, -30 },
        { -40, -20, 0, 0, 0, 0, -20, -40 },
        { -50, -40, -30, -30, -30, -30, -40, -50 }
    };

    private int[,] _fouBlanc = new int[,] {
        { -20, -10, -10, -10, -10, -10, -10, -20 },
        { -10, 0, 0, 0, 0, 0, 0, -10 },
        { -10, 0, 5, 10, 10, 5, 0, -10 },
        { -10, 5, 5, 10, 10, 5, 5, -10 },
        { -10, 0, 10, 10, 10, 10, 0, -10 },
        { -10, 10, 10, 10, 10, 10, 10, -10 },
        { -10, 5, 0, 0, 0, 0, 5, -10 },
        { -20, -10, -10, -10, -10, -10, -10, -20 }
    };

    private int[,] _fouNoir = new int[,] {
        { -20, -10, -10, -10, -10, -10, -10, -20 },
        { -10, 5, 0, 0, 0, 0, 5, -10 },
        { -10, 10, 10, 10, 10, 10, 10, -10 },
        { -10, 0, 10, 10, 10, 10, 0, -10 },
        { -10, 5, 5, 10, 10, 5, 5, -10 },
        { -10, 0, 5, 10, 10, 5, 0, -10 },
        { -10, 0, 0, 0, 0, 0, 0, -10 },
        { -20, -10, -10, -10, -10, -10, -10, -20 },
    };

    private int[,] _tourBlanc = new int[,] {
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 5, 10, 10, 10, 10, 10, 10, 5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { 0, 0, 0, 5, 5, 0, 0, 0 }
    };

    private int[,] _tourNoir = new int[,] {
        { 0, 0, 0, 5, 5, 0, 0, 0 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { -5, 0, 0, 0, 0, 0, 0, -5 },
        { 5, 10, 10, 10, 10, 10, 10, 5 },
        { 0, 0, 0, 0, 0, 0, 0, 0 }
    };

    private int[,] _reineBlanc = new int[,] {
        { -20, -10, -10, -5, -5, -10, -10, -20 },
        { -10, 0, 0, 0, 0, 0, 0, -10 },
        { -10, 0, 5, 5, 5, 5, 0, -10 },
        { -5, 0, 5, 5, 5, 5, 0, -5 },
        { 0, 0, 5, 5, 5, 5, 0, -5 },
        { -10, 5, 5, 5, 5, 5, 0, -10 },
        { -10, 0, 5, 0, 0, 0, 0, -10 },
        { -20, -10, -10, -5, -5, -10, -10, -20 }
    };

    private int[,] _reineNoir = new int[,] {
        { -20, -10, -10, -5, -5, -10, -10, -20 },
        { -10, 0, 5, 0, 0, 0, 0, -10 },
        { -10, 5, 5, 5, 5, 5, 0, -10 },
        { 0, 0, 5, 5, 5, 5, 0, -5 },
        { -5, 0, 5, 5, 5, 5, 0, -5 },
        { -10, 0, 5, 5, 5, 5, 0, -10 },
        { -10, 0, 0, 0, 0, 0, 0, -10 },
        { -20, -10, -10, -5, -5, -10, -10, -20 }
    };

    private int[,] _roiBlanc = new int[,] {
        { -30, -40, -40, -50, -50, -40, -40, -30 },
        { -30, -40, -40, -50, -50, -40, -40, -30 },
        { -30, -40, -40, -50, -50, -40, -40, -30 },
        { -30, -40, -40, -50, -50, -40, -40, -30 },
        { -20, -30, -30, -40, -40, -30, -30, -20 },
        { -10, -20, -20, -20, -20, -20, -20, -10 },
        { 20, 20, 0, 0, 0, 0, 20, 20 },
        { 20, 30, 10, 0, 0, 10, 30, 20 }
    };

    private int[,] _roiNoir = new int[,] {
        { 20, 30, 10, 0, 0, 10, 30, 20 },
        { 20, 20, 0, 0, 0, 0, 20, 20 },
        { -10, -20, -20, -20, -20, -20, -20, -10 },
        { -20, -30, -30, -40, -40, -30, -30, -20 },
        { -30, -40, -40, -50, -50, -40, -40, -30 },
        { -30, -40, -40, -50, -50, -40, -40, -30 },
        { -30, -40, -40, -50, -50, -40, -40, -30 },
        { -30, -40, -40, -50, -50, -40, -40, -30 }
    };

    public void Evaluate(Node node, Factions iaFaction) {
        //Calcul les points du tableau en ajoutant les points des pièces allié et retirants les points des pièces ennemies
        //Calcul selon la position de la pièce dans l'échiquier en se référençant sur le tableau de valeurs de la pièce
        node.AIPoints = 0;
        foreach (var variable in node.Table) {
            switch (variable) {
                case null: {
                    break;
                }
                case Tour: {
                    if (variable.Faction == Factions.Noir) {
                        if (_tourNoir != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _tourNoir[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _tourNoir[variable.Position.x, variable.Position.y];
                            }
                        }
                    }
                    else {
                        if (_tourBlanc != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _tourBlanc[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _tourBlanc[variable.Position.x, variable.Position.y];
                            }
                        }
                    }

                    break;
                }
                case Cavalier: {
                    if (variable.Faction == Factions.Noir) {
                        if (_cavalierNoir != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _cavalierNoir[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _cavalierNoir[variable.Position.x, variable.Position.y];
                            }
                        }
                    }
                    else {
                        if (_cavalierBlanc != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _cavalierBlanc[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _cavalierBlanc[variable.Position.x, variable.Position.y];
                            }
                        }
                    }

                    break;
                }
                case Fou: {
                    if (variable.Faction == Factions.Noir) {
                        if (_fouNoir != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _fouNoir[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _fouNoir[variable.Position.x, variable.Position.y];
                            }
                        }
                    }
                    else {
                        if (_fouBlanc != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _fouBlanc[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _fouBlanc[variable.Position.x, variable.Position.y];
                            }
                        }
                    }

                    break;
                }
                case Roi: {
                    if (variable.Faction == Factions.Noir) {
                        if (_roiNoir != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _roiNoir[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _roiNoir[variable.Position.x, variable.Position.y];
                            }
                        }
                    }
                    else {
                        if (_roiBlanc != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _roiBlanc[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _roiBlanc[variable.Position.x, variable.Position.y];
                            }
                        }
                    }

                    break;
                }
                case Reine: {
                    if (variable.Faction == Factions.Noir) {
                        if (_reineNoir != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _reineNoir[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _reineNoir[variable.Position.x, variable.Position.y];
                            }
                        }
                    }
                    else {
                        if (_reineBlanc != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _reineBlanc[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _reineBlanc[variable.Position.x, variable.Position.y];
                            }
                        }
                    }

                    break;
                }
                case Pion: {
                    if (variable.Faction == Factions.Noir) {
                        if (_pionNoir != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _pionNoir[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _pionNoir[variable.Position.x, variable.Position.y];
                            }
                        }
                    }
                    else {
                        if (_pionBlanc != null) {
                            if (variable.Faction == iaFaction) {
                                node.AIPoints += variable.Value;
                                node.AIPoints += _pionBlanc[variable.Position.x, variable.Position.y];
                            }
                            else {
                                node.AIPoints -= variable.Value;
                                node.AIPoints -= _pionBlanc[variable.Position.x, variable.Position.y];
                            }
                        }
                    }

                    break;
                }
            }
        }
    }
}