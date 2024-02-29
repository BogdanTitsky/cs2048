using Zenject;
using UnityEngine;
using TMPro;

public class Installer : MonoInstaller
{
    [SerializeField] private Merger merger;
    [SerializeField] private Board board;
    [SerializeField] private Grid grid;
    [SerializeField] private GameController gameController;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private TileStates tileStates;
    [SerializeField] private Score score;
    [SerializeField] private PopUpGameOver gameOverPopUp;
    [SerializeField] private TextMeshProUGUI scoreText;

    public override void InstallBindings()
    {
        Container.Bind<Merger>().FromInstance(merger).AsSingle();
        Container.Bind<Board>().FromInstance(board).AsSingle();
        Container.Bind<Grid>().FromInstance(grid).AsSingle();
        Container.Bind<GameController>().FromInstance(gameController).AsSingle();
        Container.Bind<Tile>().FromInstance(tilePrefab).AsSingle();
        Container.Bind<Score>().FromInstance(score).AsSingle();
        Container.Bind<PopUpGameOver>().FromInstance(gameOverPopUp).AsSingle();
        Container.Bind<TileStates>().FromInstance(tileStates).AsSingle();
        Container.Bind<TextMeshProUGUI>().FromInstance(scoreText).AsSingle();

    }
}
