using System;
using System.Collections.Generic;

namespace WestWorld
{
    public class EntityManager
    {
        Dictionary<int, BaseEntity> entityMap = new Dictionary<int, BaseEntity>();

        //Singleton
        static EntityManager instance = null;

        public static EntityManager Instance()
        {
            if (instance == null)
            {
                instance = new EntityManager();
            }
            return instance;
        }

        EntityManager() { }

        public void RegisterEntity(BaseEntity entity)
        {
            this.entityMap.Add(entity.id, entity);
        }

        public BaseEntity GetEntity(int id)
        {
            return this.entityMap[id];
        }

        public void UnregisterEntity(BaseEntity entity)
        {
            if (this.entityMap.ContainsKey(entity.id))
            {
                this.entityMap.Remove(entity.id);
            }
        }
    }
}
