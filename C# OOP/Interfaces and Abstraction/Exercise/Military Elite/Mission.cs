using Military_Elite.Contracts;

namespace Military_Elite
{
    public class Mission : IMission
    {
        public string CodeName { get; private set; }

        public string State { get; private set; }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}