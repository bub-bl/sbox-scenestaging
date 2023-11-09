using Sandbox;

public sealed class HealthSystem : BaseComponent
{
    private int _health;

    [Property] public int HealthMax { get; set; }

    public override void OnStart()
    {
        _health = HealthMax;
    }

    public override void Update()
    {
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health > 0) return;
        Kill();
    }

    private void Kill()
    {
        Destroy();
    }
}