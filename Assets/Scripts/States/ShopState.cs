public class ShopState : State
{
    public ShopState(GameManager gameManager) : base(StateType.Shop, gameManager)
    {

    }
    public override void Enter()
    {
        base.Enter();
        _gameManager.PlayFabManager.PlayFabShopManager.Initialize();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        _gameManager.UIManager.ShopUI.ContentHide();
        base.Exit();
    }
}
