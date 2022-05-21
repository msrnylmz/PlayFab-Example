using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    private Dictionary<int, IState> _states;
    public IState CurrentState { get; private set; }
    public IState PreviousState { get; private set; }

    private bool _inTransition;

    public StateManager()
    {
        _inTransition = false;
        CurrentState = null;
        PreviousState = null;
        _states = new Dictionary<int, IState>();
    }
    public void StartState(State.StateType state)
    {
        PreviousState = null;
        CurrentState = _states[0];
        CurrentState.Enter();
    }
    public void AddState(IState state)
    {
        _states.Add(state.ID, state);
    }

    public State.StateType GetCurrentStateEnum()
    {
        return (State.StateType)CurrentState.ID;
    }
    public void RevertState()
    {
        if (PreviousState != null)
            ChangeState((State.StateType)PreviousState.ID);
    }
    public void ChangeState(State.StateType state)
    {
        int stateID = (int)state;

        if (CurrentState.ID == stateID || _inTransition)
            return;

        if (_states.ContainsKey(stateID))
        {
            _inTransition = true;
            IState newState = _states[stateID];

            if (CurrentState != null)
                CurrentState.Exit();

            PreviousState = CurrentState;
            CurrentState = newState;
            CurrentState.Enter();
        }
        _inTransition = false;
    }

    public void UpdateController()
    {
        if (CurrentState != null && !_inTransition)
        {
            CurrentState.Update();
        }
    }
}
