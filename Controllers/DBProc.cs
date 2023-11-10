using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netMauiEjercicio1_4.Models;

namespace netMauiEjercicio1_4.Controllers
{
    public class DBProc
    {
        readonly SQLiteAsyncConnection _connection;

        public DBProc() { }
        public DBProc(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            //**Todos los objetos de bases de datos**

            //Crea una tabla tomando en cuenta los parametros de la clase Personas
            _connection.CreateTableAsync<ClassPerson>().Wait();
        }
        /*CRUD de la BDPROC*/
        //CREATE, READ, UPDATE, DELETE

        public Task<int> addPerson(ClassPerson person)
        {
            if (person.Id == 0)
            {
                return _connection.InsertAsync(person);
            }
            else
            {
                return _connection.UpdateAsync(person);
            }
        }
        public Task<List<ClassPerson>> listPerson()
        {
            return _connection.Table<ClassPerson>().ToListAsync();
        }

        public Task<ClassPerson> GetPersonID(int id)
        {
            return _connection.Table<ClassPerson>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePerson(ClassPerson personas)
        {
            return _connection.DeleteAsync(personas);
        }


    }
}
