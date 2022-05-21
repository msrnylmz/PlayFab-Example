public class InventoryState : State
{
    public InventoryState(GameManager gameManager) : base(StateType.Inventory, gameManager)
    {

    }
    public override void Enter()
    {
        base.Enter();
        _gameManager.PlayFabManager.PlayFabInventoryManager.Initialize();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        _gameManager.UIManager.InventoryUI.ContentHide();
        base.Exit();
    }
}
