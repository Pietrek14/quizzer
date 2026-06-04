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
        public Repository<Question> Questions { get; set; } = new Repository<Question>();

        public Quiz() {
            this.Id = Guid.NewGuid();
        }

        public Quiz(Guid id) {
            this.Id = id;
        }
    }
}
