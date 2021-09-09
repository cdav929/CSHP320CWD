using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheLearningCenter.Repository
{
    public interface IClassesRepository
    {
        ClassModel[] Classes { get; }
        ClassModel Class (int ClassId);
    }

    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClassesRepository : IClassesRepository
    {
        public ClassModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Classes
                                               .Select(t => new ClassModel { Id = t.ClassId, Name = t.ClassName })
                                               .ToArray();
            }
        }

        public ClassModel Class(int ClassId)
        {
            var Class = DatabaseAccessor.Instance.Classes
                                                   .Where(t => t.ClassId == ClassId)
                                                   .Select(t => new ClassModel { Id = t.ClassId, Name = t.ClassName })
                                                   .First();
            return Class ;
        }
    }
}
