
namespace Library.DLL.Interfaces
{
    internal interface IRepository<Entity> where Entity : class
    {
        public Entity Create(Entity entity);
        public Entity Remove(int Id);
        public Entity Update(Entity entity);
        public Entity Get(int Id);
        public Entity Get();
    }
}
