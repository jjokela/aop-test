using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public class LoggerRepository<T> : IRepository<T>
    {
        private readonly IRepository<T> _decorated;

        /// <summary>
        /// Loggaa
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="arg"></param>
        private void Log(string msg, object arg = null) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public LoggerRepository(IRepository<T> decorated)
        {
            _decorated = decorated;
        }

        public void Add(T entity)
        {
            Log("In decorator - before adding {0}", entity);
            _decorated.Add(entity);
            Log("In decorator - after adding {0}", entity);
        }

        public void Delete(T entity)
        {
            Log("In decorator - before deleting {0}", entity);
            _decorated.Delete(entity);
            Log("In decorator - after deleting {0}", entity);
        }

        public void Update(T entity)
        {
            Log("In decorator - before updating {0}", entity);
            _decorated.Update(entity);
            Log("In decorator - after updating {0}", entity);
        }

        public IEnumerable<T> GetAll()
        {
            Log("In decorator - before getting all entities");
            var result = _decorated.GetAll();
            Log("In decorator - after getting all entities");
            return result;
        }

        public T GetById(int id)
        {
            Log("In decorator - before getting entity {0}", id);
            var entity = _decorated.GetById(id);
            Log("In decorator - after getting entity {0}", id);
            return entity;
        }
    }
}

