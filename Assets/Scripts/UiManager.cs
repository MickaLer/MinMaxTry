using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    private static Image _turn;
    [SerializeField] private Image turnImage;

    private void Awake() {
        _turn = turnImage;
    }

    public void ChangeTurnImage(Factions actualTurn) {
        if (actualTurn == Factions.Blanc) {
            _turn.color = Color.white;
            _turn.GetComponentInChildren<Text>().color = Color.black;
            _turn.GetComponentInChildren<Text>().text = "White Turn";
        }
        else {
            _turn.color = Color.black;
            _turn.GetComponentInChildren<Text>().color = Color.white;
            _turn.GetComponentInChildren<Text>().text = "Black Turn";
        }
    }
}