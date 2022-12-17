
namespace P04.Recharge
{
    using System.Collections.Generic;

    public class RechargeStation
    {
        public void RechargeEntities(ICollection<IRechargeable> entities)
        {
            foreach (var entity in entities)
            {
                entity.Recharge();
            }
        }
    }
}
