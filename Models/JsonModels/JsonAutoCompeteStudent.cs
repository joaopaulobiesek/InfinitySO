
namespace InfinitySO.Models.JsonModels
{
    public class JsonAutoCompeteStudent
    {
        public string Name { get; set; }

        public JsonAutoCompeteStudent()
        {
        }


        public JsonAutoCompeteStudent(string name)
        {
            Name = name;
        }
    }
}
