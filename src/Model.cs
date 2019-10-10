using System.Collections.Generic;

namespace src
{
    public class Model
    {
        public Model()
        {
            RelatedModels = new List<Related>();
        }
        public string Id { get; set; }
        public virtual ICollection<Related> RelatedModels {get;set;}

    }
}