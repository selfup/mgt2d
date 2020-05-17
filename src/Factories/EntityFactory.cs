using System.Collections.Generic;

namespace Mg.Temp {
    public class EntityFactory {

        public List<EntityTag> entities;
        public EntityFactory(List<EntityTag> entityList) {
            entities = entityList;
        }
    }
}
