using System;

namespace Models.DatabaseModels
{
    public class Contractor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}