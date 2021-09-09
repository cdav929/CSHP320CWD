using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IClassManager
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int ClassId);
    }

    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClassModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class ClassManager : IClassManager
    {
        private readonly IClassesRepository ClassesRepository;

        public ClassManager(IClassesRepository ClassesRepository)
        {
            this.ClassesRepository = ClassesRepository;
        }

        public ClassModel[] Classes
        {
            get
            {
                return ClassesRepository.Classes
                                         .Select(t => new ClassModel(t.Id, t.Name))
                                         .ToArray();
            }
        }

        public ClassModel Class (int ClassId)
        {
            var classModel = ClassesRepository.Class(ClassId);
            return new ClassModel(classModel.Id, classModel.Name);
        }
    }
}
