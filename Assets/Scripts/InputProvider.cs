using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class InputProvider : ObservableTriggerBase
{
    Subject<Vector2> onAxisChanged;
    private Subject<Unit> onAttackChanged;
    private bool resetTheAxis;

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            resetTheAxis = true;
            onAxisChanged?.OnNext(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        else if (resetTheAxis)
        {
            resetTheAxis = false;
            onAxisChanged?.OnNext(Vector2.zero);
        }

        if (Input.GetAxis("Fire1") != 0)
        {
            onAttackChanged?.OnNext(Unit.Default);
        }
    }

    public Subject<Vector2> OnAxisChangedAsObservable()
    {
        return onAxisChanged ?? (onAxisChanged = new Subject<Vector2>());
    }

    public Subject<Unit> OnAttackAxisChangedAsObservable()
    {
        return onAttackChanged ?? (onAttackChanged = new Subject<Unit>());
    }

    protected override void RaiseOnCompletedOnDestroy()
    {
        onAxisChanged?.OnCompleted();
        onAttackChanged?.OnCompleted();
    }
}