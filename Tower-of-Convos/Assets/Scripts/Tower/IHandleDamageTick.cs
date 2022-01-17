
public interface IHandleDamageTick{

    ///<summary>
    ///This functions handels a single tick of a entity 
    ///</summary>
    ///<param name="entity">
    ///The entity that recives the damage
    ///</param>
    ///<returns>
    ///The damage the entity will take
    ///</returns>
    public int damageTick(Entity entity);
}