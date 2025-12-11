using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour {
    public static Factions Tour;
    public static List<GameObject> Places = new();

    [Header("UI")] 
    [SerializeField] private GameObject gridLayout;
    [SerializeField] private UiManager uiManager;

    [Header("Pieces")] 
    [SerializeField] private GameObject pionN;
    [SerializeField] private GameObject tourN;
    [SerializeField] private GameObject cavalierN;
    [SerializeField] private GameObject fouN;
    [SerializeField] private GameObject reineN;
    [SerializeField] private GameObject roiN;
    [SerializeField] private GameObject pionB;
    [SerializeField] private GameObject tourB;
    [SerializeField] private GameObject cavalierB;
    [SerializeField] private GameObject fouB;
    [SerializeField] private GameObject reineB;
    [SerializeField] private GameObject roiB;

    [Header("MiniMax")] 
    [SerializeField] private int profondeur;
    [SerializeField] private Evaluater evaluater;

    [Header("Preference")] 
    [SerializeField] private bool manual;
    [SerializeField] private IaPower iaPower;

    private Node _originalNode = new(new Pieces[,] {
        {
            new Tour(500, Factions.Noir, "TourN", new Vector2Int(0, 0)),
            new Cavalier(320, Factions.Noir, "CavalierN", new Vector2Int(0, 1)),
            new Fou(330, Factions.Noir, "FouN", new Vector2Int(0, 2)),
            new Roi(20000, Factions.Noir, "RoiN", new Vector2Int(0, 3)),
            new Reine(900, Factions.Noir, "ReineN", new Vector2Int(0, 4)),
            new Fou(330, Factions.Noir, "FouN", new Vector2Int(0, 5)),
            new Cavalier(320, Factions.Noir, "CavalierN", new Vector2Int(0, 6)),
            new Tour(500, Factions.Noir, "TourN", new Vector2Int(0, 7))
        }, {
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 0), new Vector2Int(1, 0)),
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 1), new Vector2Int(1, 1)),
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 2), new Vector2Int(1, 2)),
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 3), new Vector2Int(1, 3)),
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 4), new Vector2Int(1, 4)),
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 5), new Vector2Int(1, 5)),
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 6), new Vector2Int(1, 6)),
            new Pion(100, Factions.Noir, "PionN", new Vector2Int(1, 7), new Vector2Int(1, 7))
        },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null }, {
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 0), new Vector2Int(6, 0)),
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 1), new Vector2Int(6, 1)),
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 2), new Vector2Int(6, 2)),
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 3), new Vector2Int(6, 3)),
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 4), new Vector2Int(6, 4)),
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 5), new Vector2Int(6, 5)),
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 6), new Vector2Int(6, 6)),
            new Pion(100, Factions.Blanc, "PionB", new Vector2Int(6, 7), new Vector2Int(6, 7))
        }, {
            new Tour(500, Factions.Blanc, "TourB", new Vector2Int(7, 0)),
            new Cavalier(320, Factions.Blanc, "CavalierB", new Vector2Int(7, 1)),
            new Fou(330, Factions.Blanc, "FouB", new Vector2Int(7, 2)),
            new Roi(20000, Factions.Blanc, "RoiB", new Vector2Int(7, 3)),
            new Reine(900, Factions.Blanc, "ReineB", new Vector2Int(7, 4)),
            new Fou(330, Factions.Blanc, "FouB", new Vector2Int(7, 5)),
            new Cavalier(320, Factions.Blanc, "CavalierB", new Vector2Int(7, 6)),
            new Tour(500, Factions.Blanc, "TourB", new Vector2Int(7, 7))
        }
    });

    private float _timer;
    private Stopwatch _stopwatch;

    private void Start() {
        for (var i = 0; i < gridLayout.transform.childCount; i++)
            Places.Add(gridLayout.transform.GetChild(i).gameObject);
        Tour = Factions.Blanc;
        uiManager.ChangeTurnImage(Tour);
        ChessManager(_originalNode, _originalNode, true);
    }

    private void Update() {
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
        _timer += Time.deltaTime;
        if (_timer > 1.5f && !manual) {
            _timer = 0;
            StartingPoint(_originalNode);
            Debug.Log(_stopwatch.Elapsed.ToString().Remove(8));
            _stopwatch.Stop();
        }
        else if (manual && _timer > 0.5f && Input.GetButtonDown("Jump")) {
            _timer = 0;
            StartingPoint(_originalNode);
            Debug.Log(_stopwatch.Elapsed.ToString().Remove(8));
            _stopwatch.Stop();
        }
    }

    private void StartingPoint(Node node) {
        var oldNode = node;
        _originalNode = FindBestMove(_originalNode);
        Tour = Tour == Factions.Blanc ? Factions.Noir : Factions.Blanc;
        uiManager.ChangeTurnImage(Tour);
        ChessManager(_originalNode, oldNode, false);
        _originalNode.ChildNodes.Clear();
    }

    private Node FindBestMove(Node node) {
        var actualTurn = Tour == Factions.Blanc ? Factions.Noir : Factions.Blanc;
        var bestValue = int.MinValue;
        Node bestNode = null;
        switch (iaPower) {
            case IaPower.MiniMax:
                foreach (var childNode in node.GetChilds(Tour, node).ToList()) {
                    childNode.AIPoints = MiniMax(childNode, profondeur - 1, false, actualTurn);
                    if (childNode.AIPoints > bestValue) {
                        bestValue = childNode.AIPoints;
                        bestNode = childNode;
                    }
                }

                break;
            case IaPower.MiniMaxAlphaBetaPrunning:
                foreach (var childNode in node.GetChilds(Tour, node).ToList()) {
                    childNode.AIPoints = MiniMaxElagageAlphaBeta(childNode, profondeur - 1, int.MinValue, int.MaxValue,
                        false, actualTurn);
                    if (childNode.AIPoints > bestValue) {
                        bestValue = childNode.AIPoints;
                        bestNode = childNode;
                    }
                }

                break;
            case IaPower.NegaMax:
                foreach (var childNode in node.GetChilds(Tour, node).ToList()) {
                    childNode.AIPoints = NegaMax(childNode, profondeur - 1, actualTurn);
                    if (childNode.AIPoints > bestValue) {
                        bestValue = childNode.AIPoints;
                        bestNode = childNode;
                    }
                }

                break;
        }

        return bestNode;
    }

    private int MiniMax(Node node, int depth, bool maximizingPlayer, Factions actualTurn) {
        actualTurn = actualTurn == Factions.Blanc ? Factions.Noir : Factions.Blanc;
        if (depth == 0 || node.IsTerminal) {
            evaluater.Evaluate(node, actualTurn);
            return node.AIPoints;
        }

        node.GetChilds(actualTurn, node);
        if (maximizingPlayer) {
            var value = int.MinValue;
            foreach (var childNode in node.ChildNodes) {
                value = Math.Max(value, MiniMax(childNode, depth - 1, false, actualTurn));
            }

            node.AIPoints = value;
            return value;
        }
        else {
            var value = int.MaxValue;
            foreach (var childNode in node.ChildNodes) {
                value = Math.Min(value, MiniMax(childNode, depth - 1, true, actualTurn));
            }

            node.AIPoints = value;
            return value;
        }
    }

    private int MiniMaxElagageAlphaBeta(Node node, int depth, int alpha, int beta, bool maximizingPlayer,
        Factions actualTurn) {
        actualTurn = actualTurn == Factions.Blanc ? Factions.Noir : Factions.Blanc;
        if (depth == 0 || node.IsTerminal) {
            evaluater.Evaluate(node, Tour);
            return node.AIPoints;
        }

        if (maximizingPlayer) {
            var value = int.MinValue;
            foreach (var childNode in node.GetChilds(actualTurn, node)) {
                value = Math.Max(value, MiniMaxElagageAlphaBeta(childNode, depth - 1, alpha, beta, false, actualTurn));
                if (value >= beta) break;
                alpha = Math.Max(alpha, value);
            }

            node.AIPoints = value;
            return value;
        }
        else {
            var value = int.MaxValue;
            foreach (var childNode in node.GetChilds(actualTurn, node)) {
                value = Math.Min(value, MiniMaxElagageAlphaBeta(childNode, depth - 1, alpha, beta, true, actualTurn));
                if (alpha >= value) break;
                beta = Math.Min(value, beta);
            }

            node.AIPoints = value;
            return value;
        }
    }

    // Work In Progress
    private int NegaMax(Node node, int depth, Factions actualTurn) {
        int color;
        actualTurn = actualTurn == Factions.Blanc ? Factions.Noir : Factions.Blanc;
        if (actualTurn == Tour) color = 1;
        else color = -1;
        if (depth == 0 || node.IsTerminal) {
            evaluater.Evaluate(node, actualTurn);
            return node.AIPoints * color;
        }

        var value = int.MinValue;
        foreach (var childNode in node.GetChilds(actualTurn, node)) {
            value = Math.Max(value, -NegaMax(childNode, depth - 1, actualTurn));
        }

        node.AIPoints = value;
        return value;
    }

    private void ChessManager(Node node, Node oldNode, bool startingPoint) {
        for (var i = 0; i < 8; i++)
        for (var j = 0; j < 8; j++) {
            if (node.Table[i, j] == null) {
                if (Places[i * 8 + j].transform.childCount != 0)
                    Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                continue;
            }

            if (!startingPoint && oldNode.Table[i, j] == node.Table[i, j]) continue;
            switch (node.Table[i, j].Tag) {
                case "TourN": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(tourN, Places[i * 8 + j].transform);
                    break;
                }
                case "CavalierN": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(cavalierN, Places[i * 8 + j].transform);
                    break;
                }
                case "FouN": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(fouN, Places[i * 8 + j].transform);
                    break;
                }
                case "RoiN": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(roiN, Places[i * 8 + j].transform);
                    break;
                }
                case "ReineN": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(reineN, Places[i * 8 + j].transform);
                    break;
                }
                case "PionN": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(pionN, Places[i * 8 + j].transform);
                    break;
                }
                case "TourB": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(tourB, Places[i * 8 + j].transform);
                    break;
                }
                case "CavalierB": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(cavalierB, Places[i * 8 + j].transform);
                    break;
                }
                case "FouB": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(fouB, Places[i * 8 + j].transform);
                    break;
                }
                case "RoiB": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(roiB, Places[i * 8 + j].transform);
                    break;
                }
                case "ReineB": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(reineB, Places[i * 8 + j].transform);
                    break;
                }
                case "PionB": {
                    if (Places[i * 8 + j].transform.childCount != 0)
                        Destroy(Places[i * 8 + j].transform.GetChild(0).gameObject);
                    Instantiate(pionB, Places[i * 8 + j].transform);
                    break;
                }
            }
        }
    }
}