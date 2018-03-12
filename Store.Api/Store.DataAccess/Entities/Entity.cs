using System;

namespace Store.DataAccess.Entities
{
    /// <summary>
    /// Entity base class.
    /// </summary>
    [Serializable]
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}