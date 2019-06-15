using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Common
{
    public class BaseClass<T>
    {
        public virtual int ID { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }

        public BaseClass()
        {
            ID = -1;
        }
        public virtual void Save()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            BaseRepository<T> repo = new BaseRepository<T>();

            repo.Save(this);
        }

        public virtual void Delete()
        {
            BaseRepository<T> repo = new BaseRepository<T>();

            repo.Delete(this);
        }

        public virtual void Update()
        {
            this.UpdatedAt = DateTime.Now;
            BaseRepository<T> repo = new BaseRepository<T>();
            repo.Update(this);
        }

        public static List<T> GetAll()
        {
            BaseRepository<T> repo = new BaseRepository<T>();
            return (List<T>)repo.GetAll();
        }

        public static T GetByID(int ID)
        {
            BaseRepository<T> repo = new BaseRepository<T>();

            return repo.GetById(ID);
        }

		public static void DeleteAll()
		{
			var repo = new BaseRepository<T>();

			repo.DeleteAll();
		}

		public override string ToString()
		{
			return ID.ToString();
		}

		public override int GetHashCode()
		{
			return ID;
		}
	}
}
