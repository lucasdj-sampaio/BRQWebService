namespace BRQWebService.Interfaces
{
    public interface ICandidate
    {
        public string? Name { get; set; }

        public long Cpf { get; set; }

        public string? Email { get; set; }

        public long CellPhone { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}