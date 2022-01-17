[System.Serializable]
public class DamageSource {
    public float amount;
    public IHandleDamageTick damageTick;
    public bool isSingle;
    public float duration;
    public string SourceName;
}