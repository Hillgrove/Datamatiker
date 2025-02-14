
namespace Protocol
{
    internal class Receiver
    {
        private PersonRepository _repo = new PersonRepository();

        public void Receive(string message)
        {
            var instructions = message.Split('|');          
            string action = instructions[0].ToLower();
            switch (action)
            {
                case "create":
                    if (instructions.Length == 4) // message contains all datapoints to create a Person
                    {
                        _repo.Create(instructions);
                    }
                    break;

                case "read":
                    if (instructions.Length == 2) // message contains instruction and id
                    {
                        _repo.Read(instructions);
                    }
                    break;

                case "update":
                    if (instructions.Length == 5) // message contains all datapoints to update a Person
                    {
                        _repo.Update(instructions);
                    }
                    break;

                case "delete":
                    if (instructions.Length == 2) // message contains instruction and id
                    {
                        _repo.Delete(instructions);
                    }
                    break;
            }

        }
    }
}

