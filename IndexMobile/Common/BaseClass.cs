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
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }

        public BaseClass()
        {
            this.ID = -1;
        }
        public virtual void Save()
        {
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
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
            this.updated_at = DateTime.Now;
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



    }
}
