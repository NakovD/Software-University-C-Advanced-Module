namespace Easter.Models.Workshops
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy == 0 || bunny.Dyes.All(d => d.IsFinished())) return;

            var dye = bunny.Dyes.FirstOrDefault(d => !d.IsFinished());

            while (!egg.IsDone() && bunny.Energy > 0)
            {
                egg.GetColored();
                bunny.Work();
                dye.Use();
                if (dye.IsFinished())
                {
                    dye = bunny.Dyes.FirstOrDefault(d => !d.IsFinished());
                }
                if (dye == null) break;
            }
        }
    }
}
