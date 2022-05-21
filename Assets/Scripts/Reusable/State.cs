public class State : IState
{
    public enum StateType
    {
        LoginMenu,
        MainMenu,
        Inventory,
        Shop,
        Leaderboard,
        GamePlay,
        GameOver,
    }

    protected StateType _stateType;
    protected GameManager _gameManager;
    protected StateManager _stateManager;

    public State(StateType stateType, GameManager gameManager)
    {
        _gameManager = gameManager;
        _stateManager = gameManager.GameStateManager;
        _stateType = stateType;
        _ID = (int)_stateType;
    }

    private int _ID;
    public int ID { get { return _ID; } }

    public virtual void Enter()
    {
        _gameManager.UIManager.ChangePanel(_stateType);
    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }
}
