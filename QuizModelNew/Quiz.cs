using QuizModel.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Quiz : IGuided
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public GuidRepository<Question> Questions { get; set; } = new GuidRepository<Question>();

        public Quiz() : this("") { }
        public Quiz(String name) : this(Guid.NewGuid(), name) { }

        public Quiz(Guid id, String name) {
            this.Id = id;
            this.Name = name;
        }
    }
}
