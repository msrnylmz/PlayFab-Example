public class LeaderboardState : State
{
    public LeaderboardState(GameManager gameManager) : base(StateType.Leaderboard, gameManager)
    {

    }
    public override void Enter()
    {
        base.Enter();
        _gameManager.UIManager.LeaderboardUI.ShowLeaderboard();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        _gameManager.UIManager.LeaderboardUI.ContentHide();
        base.Exit();
    }
}
